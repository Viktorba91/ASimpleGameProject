using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASimpleGameProject.GameFolder;
using ASimpleGameProject.GameFolder.Functions;
using ASimpleGameProject.GameFolder.Menu;

namespace ASimpleGameProject.Menu
{
    public class MainMenu
    {
        public MainMenu()
        {
            MainMenuChoose();
        }
        private void MainMenuChoose()
        {
            string[] MainMenuChoices = { "New Game", "Load Game", "Options", "Exit Game" };

            int menuTask = Navigation.MultipleChoice(true, MainMenuChoices);
            if (menuTask == 0)
            {
                Game game = new Game();
            }
            else if (menuTask == 1) { WorkInProgress.NotAvailable("MainMenu"); }
            else if (menuTask == 2) { WorkInProgress.NotAvailable("MainMenu"); }
            if (menuTask == 3)
            {
                Environment.Exit(1);
            }

        }

    }
}
