using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASimpleGameProject.GameFolder;
using ASimpleGameProject.GameFolder.Functions;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.SaveLoad;

namespace ASimpleGameProject.Menu
{
    public class MainMenu
    {
        public MainMenu()
        {
            Console.Clear();
            MainMenuChoose();
        }
        private void MainMenuChoose()
        {
            UpdateConsoleView.UpdateView("Menu");

            string[] MainMenuChoices = { "New Game", "Load Game", "Exit Game" };

            int menuTask = Navigation.MultipleChoice(true, MainMenuChoices);
            if (menuTask == 0)
            {
                UpdateConsoleView.UpdateView("Menu");
                Game game = new Game();
            }
            else if (menuTask == 1) { LoadGame Load = new LoadGame(); }
            else { Environment.Exit(1); }

        }

    }
}
