using ASimpleGameProject.GameFolder.Enemy;
using ASimpleGameProject.GameFolder.Levels;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder
{
    internal class UpdateConsoleView
    {
        
        
        public static void UpdateView(string currentPosition = "")
        {
            Console.Clear();
            if (currentPosition == "Menu")
            {
                Console.WriteLine("\n==================================================================");
                Console.WriteLine("--------------------- A Simple Game Project ----------------------");
                Console.WriteLine("==================================================================");
            }
            else if (currentPosition == "Not Available")
            {
                Unavailable();
            }
            else
            {
                Game.PlayerUI.GetPlayerStats(Game.Player);
            }
            

            if (currentPosition == "Battle")
            {
                EnemyHUD enemyHUD = new EnemyHUD(Battle.Enemy);
            }
            else if (currentPosition != "") 
            { 
                if (currentPosition == "The Wilderness")
                {
                    Console.WriteLine($"You are here: {currentPosition}  ||  {Game.Player.BossCountdown}");
                }
                else if(currentPosition != "Menu")
                {
                    Console.WriteLine($"You are here: {currentPosition}");
                }
                
            }
            else if (currentPosition == "NotAvailable")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(":(");
                Console.WriteLine("Application ran into a problem that it couldn't handle, and now it needs to restart.");
            }
        }
        private static void Unavailable()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(":(");
            Console.WriteLine("Program ran into a problem that it couldn't handle, and needs to restart.");
        }
    }
}
