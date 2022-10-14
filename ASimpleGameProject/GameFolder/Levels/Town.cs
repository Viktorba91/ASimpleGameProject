using ASimpleGameProject.GameFolder.Functions;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.Menu;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class Town
    {
        PlayerCharacter Player { get; set; }
        PlayerHUD PlayerUI { get; set; }
        public string CurrentPosition { get; private set; } = "Town";

        string[] ChooseTownAction = { "Enter the wilderness", "Tavern", "Class Trainer", "Save Game", "Exit to Main Menu" };

        string[] ChooseExploringAction = { "Continue exploring", "Camp", "Retreat to town" };

        string[] ChooseBossExploringAction = { "Fight boss", "Camp", "Retreat to town" };

        public Town()
        {
            //Player = player;
            //PlayerUI = playerUI;
            TownAction();
        }
        private void TownAction()
        {
            UpdateConsoleView.UpdateView("Town");

            int choice = Navigation.MultipleChoice(false, ChooseTownAction);

            if (choice == 0) { Wilderness wilderness = new Wilderness(); }
            else if (choice == 1) { Tavern tavern = new Tavern(); }
            
            //Currently not implemented
            else if (choice == 2) { WorkInProgress.NotAvailable("Town"); TownAction(); }
            else if (choice == 3) { WorkInProgress.NotAvailable("Town"); TownAction(); }

            else if (choice == 4) { Console.Clear(); MainMenu mainMenu = new MainMenu(); }

        }
        
    }
}
