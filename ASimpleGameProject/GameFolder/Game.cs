using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASimpleGameProject.GameFolder.Levels;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.Menu;
using ASimpleGameProject.Player;

namespace ASimpleGameProject.GameFolder
{
    internal class Game
    {
        public static PlayerCharacter Player { get; private set; }
        public static PlayerHUD PlayerUI { get; private set; }


        public Game()
        {
            StartGame();
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

            //Starts the game in Town
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
            if (Player.CurrentExperience > Player.NeededExperience)
            {
                int remainingExp = Player.CurrentExperience - Player.NeededExperience;
                Player.Level++;
                Player.CurrentExperience = remainingExp;
                Player.NeededExperience = Player.NeededExperience + 500;
                
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
