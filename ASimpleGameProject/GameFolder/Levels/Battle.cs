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
            EnemyCharacter enemy = new EnemyCharacter();
            Enemy = enemy;
            UpdateConsoleView.UpdateView("Battle");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("A monster appeared!");
            BattleMenu(enemy);
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
                        WorkInProgress.NotAvailable("Battle");
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
        private void Fight(EnemyCharacter enemy, bool usedItem)
        {
            //bool ShouldHit = false;
            ////Roll dice if should hit enemy or not:
            //ShouldHit = CalculateHitAndDamage(enemy, ShouldHit);

            //Player action is always first, checking if player used consumable instead of attack:
            if (!UsedItem)
            {
                PlayerDamage = rnd.Next(Game.Player.AttackPower - 15, Game.Player.AttackPower + 15);
                enemy.CurrentHealth -= PlayerDamage;
            }
            
            //Check if enemy is (still) alive
            CheckEnemyHP(enemy);

            
            if (enemy.CurrentHealth > 0)
            {
                //Check if player used consumable item or not
                if (usedItem)
                {
                    UpdateConsoleView.UpdateView("Battle");
                    Console.WriteLine($"You heal for {Game.Player.MaxHealth / 2}.");
                    UsedItem = false;
                }
                else if (!usedItem)
                {
                    EnemyDamage = rnd.Next(enemy.AttackPower - 15, enemy.AttackPower + 15);
                    Game.Player.CurrentHealth -= EnemyDamage;
                    UpdateConsoleView.UpdateView("Battle");
                    Console.WriteLine($"{Game.Player.Name} hit {enemy.Name} for {PlayerDamage} damage.");
                    
                }
                //else
                //{
                //    UpdateConsoleView.UpdateView("Battle");
                //    Console.WriteLine($"{Game.Player.Name}'s attack missed!");
                //    Console.WriteLine(ShouldHit);
                //}
 
                Console.WriteLine($"{enemy.Name} hit {Game.Player.Name} for {EnemyDamage} damage.");
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
                Game.GetExperience(enemy.Level * 10 + rnd.Next(100, 200));
                RollForLoot();

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
        private bool CalculateHitAndDamage(EnemyCharacter enemy, bool ShouldHit)
        {
            HitChanceRoll = rnd.Next(0, 100);

            if (enemy.Level > Game.Player.Level + 3 && HitChanceRoll > 50) 
            {
                ShouldHit = true;
            }
            else if (enemy.Level > Game.Player.Level + 2 && HitChanceRoll > 40)
            {
                ShouldHit = true;
            }
            else if (enemy.Level > Game.Player.Level + 1 && HitChanceRoll > 30)
                {
                    ShouldHit = true;
                }
            else if (enemy.Level > Game.Player.Level + 1 && HitChanceRoll > 20)
            {
                ShouldHit = true;
            }
            else if (enemy.Level > Game.Player.Level && HitChanceRoll > 10)
            {
                ShouldHit = true;
            }
            else if (enemy.Level < Game.Player.Level && HitChanceRoll > 5)
            {
                ShouldHit = true;
            }
            else
            {
                ShouldHit = false;
            }
            Console.Clear();
            Console.WriteLine("Hitroll was " + HitChanceRoll);
            Console.ReadKey();
            return ShouldHit;
        }
        private void RollForLoot()
        {
            LootRoll = rnd.Next(0, 5);
            if (LootRoll > 3)
            {
                Weapon weapon = new Weapon(Game.Player);
                Console.Clear();
                Console.WriteLine($"You looted a weapon from the corpse");
                Console.WriteLine($"Name: {weapon.WeaponName} | Weapon Type: {weapon.WeaponType} | Required Level: {weapon.RequiredLevel}");
                Console.WriteLine($"HP+{weapon.Health} | Strength+{weapon.Strength} | Mana+{weapon.Mana} | Agility+{weapon.Agility}");
                Console.ReadKey();
            }
            else if (LootRoll <= 3 && LootRoll > 0)
            {
                Console.Clear();
                CurrencyLoot = rnd.Next(1, 50);
                Console.WriteLine($"You found {CurrencyLoot} money.");
                Console.ReadKey();
            }
        }

    }
}
