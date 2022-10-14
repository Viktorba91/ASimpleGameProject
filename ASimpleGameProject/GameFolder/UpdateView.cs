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
            Game.PlayerUI.GetPlayerStats(Game.Player);

            if (currentPosition == "Battle")
            {
                EnemyHUD enemyHUD = new EnemyHUD(Battle.Enemy);
            }
            else if (currentPosition != "") 
            { 
                Console.WriteLine($"You are here: {currentPosition}");
            }
        }
    }
}
