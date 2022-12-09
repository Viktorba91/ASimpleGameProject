using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASimpleGameProject.GameFolder.Levels;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.GameFolder.SaveLoad;
using ASimpleGameProject.Items;
using ASimpleGameProject.Menu;
using ASimpleGameProject.Player;

namespace ASimpleGameProject.GameFolder
{
    internal class Game
    {
        public static PlayerCharacter Player { get; private set; }
        public static PlayerHUD PlayerUI { get; private set; }
        public static int BossCountdown { get; set; }
        public static bool isBoss { get; set; } = false;

        //New Game:
        public Game()
        {
            StartGame();
        }
        //Load Game:
        public Game(PlayerCharacter player)
        {
            Player = player;
            
            PlayerUI = new PlayerHUD();
            
            Town town = new Town();
        }
        private void StartGame()
        {
            Console.Clear();
            Player = CreatePlayer();
            PlayerUI = new PlayerHUD();
            
            Console.Clear();
            PlayerUI.GetPlayerStats(Player);
            Console.WriteLine("\nYou are a " + Player.ClassName + ". Your name is: " + Player.Name);
            Console.WriteLine("Press any key to start your adventure");
            Console.ReadKey();

            Player.Inventory = new List<Item>();
            //TESTING ITEMS!
            Player.Inventory.Add(new Item("Mana Brew", "Consumable", 1, 1));
            Player.Inventory.Add(new Item("Mana Brew", "Consumable", 3, 1));
            Player.Inventory.Add(new Item("Healing Potion", "Consumable", 3, 1));
            Player.Inventory.Add(new Item("Healing Potion", "Consumable", 7, 1));
            Player.Inventory.Add(new Item("Mana Brew", "Consumable", 1, 1));
            Player.Inventory.Add(new Item("Mana Brew", "Consumable", 2, 1));
            Player.Inventory.Add(new Item("Mana Brew", "Consumable", 1, 1));
            Player.Inventory.Add(new Item(new Weapon("Sword", "Surrender and Succomb, Twin Razors of Horrid Dreams", 1, 2, 2, 1, 1)));
            
            Town town = new Town();

        }
        private PlayerCharacter CreatePlayer()
        {
            CreatePlayerCharacter createCharacter = new CreatePlayerCharacter();
            PlayerCharacter player = new PlayerCharacter(createCharacter.ClassName, createCharacter.Name);
            return player;
        }

        // Gather Player Experience from slain enemy
        public static void GetExperience(int exp)
        {
            GainExperience(exp);
        }
        private static void GainExperience(int experience)
        {
            Player.CurrentExperience += experience;

                // Level up if enough experience is gained, and set remaining exp as current exp:
                //!!! Should be placed in PlayerCharacter class
            if (Player.CurrentExperience > Player.NeededExperience)
            {
                int remainingExp = Player.CurrentExperience - Player.NeededExperience;
                Player.Level++;
                Player.CurrentExperience = remainingExp;
                Player.NeededExperience = Player.NeededExperience + 500;
                
                Player.MaxHealth += 5;
                Player.CurrentHealth = Player.MaxHealth;
                Player.MaxMana += 5;
                Player.CurrentMana = Player.MaxMana;
                Player.AttackPower += 5;
                Player.Agility += 5;

                //Level up message
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.SetCursorPosition(17, 9);
                Console.WriteLine($"Congratulations!! You leveled up and are now level: {Player.Level}!");
                Console.ReadKey();
                Console.ResetColor();
            }
        }
    }
}
