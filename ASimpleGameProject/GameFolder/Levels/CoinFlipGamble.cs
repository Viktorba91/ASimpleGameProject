using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class CoinFlipGamble
    {
        public int PlacedBet { get; set; }
        private bool IsBetting = true;
        private int isHeads { get; set; }
        private int CoinFlip { get; set; }
        
        public CoinFlipGamble()
        {
            UpdateConsoleView.UpdateView();
            Random rnd = new Random();

            while (IsBetting)
            {
                Console.WriteLine("Place your bet: ");
                string bet = Console.ReadLine();
                try
                {
                    PlacedBet = Convert.ToInt32(bet);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid format. Use numbers only.");
                    Console.ReadKey();
                    Tavern goToTavern = new Tavern();
                    throw;
                }
                
                if (PlacedBet < 1 || PlacedBet > Game.Player.Currency)
                {
                    Console.WriteLine("Please place an affordable bet.");
                    Console.ReadKey();
                    Tavern goToTavern = new Tavern();
                    break;
                }
                else
                {
                    IsBetting = false;
                }
            }

            while (true)
            {
                Console.WriteLine("(1) Heads or (2) Tails?");
                string bet = Console.ReadLine();
                int userInput = Convert.ToInt32(bet);
                if (userInput == 1 || userInput == 2)
                {
                    CoinFlip = rnd.Next(0, 100);
                    
                }
                else if (userInput == 1 || userInput == 2)
                {
                    Console.WriteLine("Invalid input, try again..");
                    continue;
                }
                else
                {
                    continue;
                }

                //Lose
                if (CoinFlip <= 50)
                {
                    Game.Player.Currency -= PlacedBet;
                    if (Game.Player.Currency < 0) Game.Player.Currency = 0;
                    if (userInput == 1) Console.WriteLine($"Tails! You lose and now have {Game.Player.Currency} money.");
                    if (userInput == 2) Console.WriteLine($"Heads! You lose and now have {Game.Player.Currency} money.");
                    break;
                }
                //Win
                else
                {
                    Game.Player.Currency += PlacedBet;
                    if (userInput == 1) Console.WriteLine($"Heads! You win and now have {Game.Player.Currency} money!!");
                    if (userInput == 2) Console.WriteLine($"Tails! You win and now have {Game.Player.Currency} money!!");
                    break;
                }

            }
            Console.ReadKey();
            Tavern tavern = new Tavern();
        }
    }
}
