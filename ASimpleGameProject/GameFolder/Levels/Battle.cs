using ASimpleGameProject.GameFolder.Enemy;
using ASimpleGameProject.GameFolder.Functions;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.Items;
using ASimpleGameProject.Menu;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class Battle
    {
        public static EnemyCharacter Enemy = new EnemyCharacter();
        
        string[] BattleAction = { "Attack", "Special Attack", "Item", "Flee" };
        int PlayerDamage = 0;
        int EnemyDamage = 0;
        bool IsFighting = true;
        
        bool UsedItem = false;
        int HitChanceRoll = 0;
        int LootRoll = 0;
        int CurrencyLoot = 0;
        Random rnd = new Random();
        public Battle()
        {
            //Boss Encounter Setup
            if (Game.Player.BossCountdown < 1)
            {
                Game.isBoss = true;
            }
            else
            {
                Game.isBoss = false;
            }

            EnemyCharacter enemy = new EnemyCharacter();
            Enemy = enemy;
            UpdateConsoleView.UpdateView("Battle");
            Console.SetCursorPosition(30, 13);
            if (Game.isBoss)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.SetCursorPosition(30, 13);
                Console.WriteLine($"{Enemy.Name} approaches!");
                Console.ReadKey();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                UpdateConsoleView.UpdateView("Battle");
            }
            else
            {
                Console.WriteLine("A monster appeared!");
            }
            
            BattleMenu(enemy);
        }

        //Return to battle from SpecialAtk or Inventory Meny:
        public Battle(EnemyCharacter enemy, SpecialAttack specialAtk)
        {
            Enemy = enemy;
            UpdateConsoleView.UpdateView("Battle");
            Console.SetCursorPosition(30, 13);
            if(Game.Player.CurrentMana >= specialAtk.ManaCost && specialAtk.Name != "Go back")
            {
                Fight(enemy, UsedItem, specialAtk);
            }
            else
            {
                BattleMenu(enemy);
            }
            
        }
        private void BattleMenu(EnemyCharacter enemy)
        {
            
            int choice = Navigation.MultipleChoice(false, BattleAction);
            switch (choice)
            {
                case 0: //Attack the enemy
                    {
                        Fight(enemy, UsedItem);
                        break;
                    }
                case 1: //Mana Attack
                    {
                        SpecialAtkView specialAtk = new SpecialAtkView(enemy);
                        break;
                    }
                case 2: //Consumable items
                    {
                        BattleItem item = new BattleItem();
                        UsedItem = item.Consumables();
                        if (UsedItem)
                        {
                            Fight(enemy, UsedItem);
                        }
                        BattleMenu(enemy);
                        break;
                    }
                    
                case 3: //Flee from battle:
                    {
                        
                        Game.Player.CurrentHealth -= enemy.AttackPower / 2;
                        
                        Console.WriteLine($"\n\nYou lose {enemy.AttackPower / 2} health as you flee from the battlefield like a little chicken wimp.");
                        CheckPlayerHP();
                        if(Game.Player.CurrentHealth > 0)
                        {
                            Console.ReadKey();
                            Wilderness wilderness = new Wilderness();
                        }
                        break;
                    }
            }
           
        }
        private void Fight(EnemyCharacter enemy, bool usedItem, SpecialAttack specialAtk = null)
        {
            //bool ShouldHit = false;
            ////Roll dice if should hit enemy or not:
            //ShouldHit = CalculateHitAndDamage(enemy, ShouldHit);

            //Player action is always first, checking if player used consumable instead of attack:
            if (!UsedItem && specialAtk == null)
            {
                PlayerDamage = rnd.Next(Game.Player.AttackPower - 15, Game.Player.AttackPower + 15);
                enemy.CurrentHealth -= PlayerDamage;
                Game.Player.CurrentMana += Game.Player.Level + 5;
                if (Game.Player.CurrentMana > Game.Player.MaxMana)
                {
                    Game.Player.CurrentMana = Game.Player.MaxMana;
                }
            }
            
            //Check if enemy is still alive
            CheckEnemyHP(enemy);

            
            if (enemy.CurrentHealth > 0)
            {
                EnemyDamage = rnd.Next(enemy.AttackPower - 15, enemy.AttackPower + 15);
                if (EnemyDamage < 1) EnemyDamage = 0;

                Game.Player.CurrentHealth -= EnemyDamage;

                //Check if player used consumable item or not
                if (usedItem)
                {
                    UpdateConsoleView.UpdateView("Battle");
                    Console.WriteLine($"You heal for {Game.Player.MaxHealth / 2}.");
                    UsedItem = false;
                }
                else if (specialAtk != null)
                {
                    enemy.CurrentHealth -= specialAtk.Damage;
                    Game.Player.CurrentMana -= specialAtk.ManaCost;
                    UpdateConsoleView.UpdateView("Battle");
                    Console.WriteLine($"{Game.Player.Name} used {specialAtk.Name} for {specialAtk.Damage} damage.");
                }
                else if (!usedItem)
                {
                    UpdateConsoleView.UpdateView("Battle");
                    Console.WriteLine($"{Game.Player.Name} hit {enemy.Name} for {PlayerDamage} damage.");
                }
                

                //CHECK if enemy hit for less than 1 damage:
                if(EnemyDamage < 1)
                {
                    Console.WriteLine($"{enemy.Name}'s attack missed!");
                }
                else
                {
                    Console.WriteLine($"{enemy.Name} hit {Game.Player.Name} for {EnemyDamage} damage.");
                }

                //CHECK if player is still alive
                CheckPlayerHP();

            }

            if (IsFighting)
            {
                BattleMenu(enemy);
            }
        }

        private void CheckEnemyHP(EnemyCharacter enemy)
        {
            if (enemy.CurrentHealth <= 0)
            {
                UpdateConsoleView.UpdateView("Battle");
                Console.WriteLine($"{Game.Player.Name} hit {enemy.Name} for {Game.Player.AttackPower} damage.");
                Console.WriteLine($"\n{enemy.Name} has been slain!");
                IsFighting = false;
                Console.ReadKey();
                if (Game.isBoss)
                {
                    Game.GetExperience(enemy.Level * 20 + rnd.Next(400, 500));
                }
                else
                {
                    Game.GetExperience(enemy.Level * 10 + rnd.Next(100, 200));
                }
                
                RollForLoot();
                Game.Player.BossCountdown -= 1;
                if (Game.Player.BossCountdown < 0)
                {
                    Game.Player.BossCountdown = 4 + Game.Player.Level;
                    Game.Player.MaxBossCountdown = Game.Player.BossCountdown;
                }
                Wilderness wilderness = new Wilderness();
            }
           
        }
        private void CheckPlayerHP()
        {
            if (Game.Player.CurrentHealth <= 0) { 
                IsFighting = false;
                Console.WriteLine("You died! Game Over..");
                Console.ReadKey();
                Console.Clear();
                MainMenu mainMenu = new MainMenu();
            }
        }
        
        private void RollForLoot()
        {
            LootRoll = rnd.Next(0, 5);
            
            if (Game.isBoss)
            {
                Weapon weapon = new Weapon(Game.Player);
                Item itemWeapon = new Item(weapon);
                Game.Player.Inventory.Add(itemWeapon);
                CurrencyLoot = rnd.Next(Game.Player.Level * 100, 200);
                Game.Player.Currency += CurrencyLoot;

                Console.Clear();
                Console.WriteLine($"You found {CurrencyLoot} money.");
                Console.WriteLine($"You looted a weapon from the corpse");
                Console.WriteLine($"Name: {weapon.WeaponName} | Weapon Type: {weapon.WeaponType} | Required Level: {weapon.RequiredLevel}");
                Console.WriteLine($"HP+{weapon.Health} | Strength+{weapon.Strength} | Mana+{weapon.Mana} | Agility+{weapon.Agility}");
                Console.ReadKey();
            }
            else if (LootRoll > 3)
            {
                Weapon weapon = new Weapon(Game.Player);
                Item itemWeapon = new Item(weapon);
                Game.Player.Inventory.Add(itemWeapon);
                Console.Clear();
                Console.WriteLine($"You looted a weapon from the corpse");
                Console.WriteLine($"Name: {weapon.WeaponName} | Weapon Type: {weapon.WeaponType} | Required Level: {weapon.RequiredLevel}");
                Console.WriteLine($"HP+{weapon.Health} | Strength+{weapon.Strength} | Mana+{weapon.Mana} | Agility+{weapon.Agility}");
                Console.ReadKey();

                //foreach(var item in Game.Player.Inventory)
                //{
                //    if(!item.IsWeapon)
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        try
                //        {
                //            Console.WriteLine(item.Weapon.WeaponName);
                //        }
                //        catch (Exception)
                //        {
                //            Console.WriteLine(item.ItemName);
                //            throw;
                //        }
                       
                //    }
                //}
                //Console.ReadKey();

            }
            else if (LootRoll <= 3 && LootRoll > 0)
            {
                Console.Clear();
                CurrencyLoot = rnd.Next(1, 50);
                Game.Player.Currency += CurrencyLoot;
                Console.WriteLine($"You found {CurrencyLoot} money.");
                Console.ReadKey();
            }
        }

    }
}
