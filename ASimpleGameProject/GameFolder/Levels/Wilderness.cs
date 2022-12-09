using ASimpleGameProject.GameFolder.Enemy;
using ASimpleGameProject.GameFolder.Functions;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class Wilderness
    {
        string[] ChooseWildernessAction = { "Hunt", "Camp", "Inventory", "Back to town" };

        public Wilderness()
        {
            WildernessAction();
        }

        private void WildernessAction()
        {
            UpdateConsoleView.UpdateView("The Wilderness");
            int choice = Navigation.MultipleChoice(false, ChooseWildernessAction);

            if (choice == 0) { Battle battle = new Battle(); }
            else if (choice == 1) { WorkInProgress.NotAvailable("The Wilderness"); WildernessAction(); }
            else if (choice == 2) { BrowseInventory inventory = new BrowseInventory(); }
            else if (choice == 3) { Game.Player.BossCountdown = Game.Player.MaxBossCountdown; Town town = new Town();  }
        }

        //public void FoundEnemy(PlayerCharacter player)
        //{
        //    GenerateEnemy generatedEnemy = new GenerateEnemy();
        //    EnemyCharacter enemy = new EnemyCharacter();
        //    enemy = generatedEnemy.EnemyGenerate(player);

        //    Console.WriteLine($"{enemy.Name} appeared!");
            
            
        //    Battle battle = new Battle();
        //    battle.Fight(player, enemy);
        //    Console.WriteLine("Test");
        //}
    }
}
