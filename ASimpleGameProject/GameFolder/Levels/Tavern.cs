using ASimpleGameProject.GameFolder.Functions;
using ASimpleGameProject.GameFolder.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class Tavern
    {
        private string[] ChooseTavernAction = { "Shop", "Rest", "Gamble", "Back" };
        public void getPlayer() { }
        public Tavern()
        {
            TavernAction();
        }
        private void TavernAction()
        {
            int choice = 0;
            UpdateConsoleView.UpdateView("Tavern");

            choice = Navigation.MultipleChoice(false, ChooseTavernAction);
            //Action: Shop
            if (choice == 0) { Shop shop = new Shop(Game.Player); }
            //Action: Rest
            else if (choice == 1)
            {
                Console.Clear();
                Game.Player.CurrentHealth = Game.Player.MaxHealth;
                Game.Player.CurrentMana = Game.Player.MaxMana;
                UpdateConsoleView.UpdateView();
                Console.WriteLine("You rest for the night and heal up. \nPress any key to conitnue.");
                
                Console.ReadKey();
                TavernAction();
            }
            //Action: Gamble Minigame
            else if (choice == 2) { CoinFlipGamble gamble = new CoinFlipGamble(); }
            //Action: Back
            else if (choice == 3) {Town town = new Town(); }
        }
    }
}
