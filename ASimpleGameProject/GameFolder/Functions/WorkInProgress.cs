using ASimpleGameProject.GameFolder.Enemy;
using ASimpleGameProject.GameFolder.Levels;
using ASimpleGameProject.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Functions
{
    internal class WorkInProgress
    {
        public static void NotAvailable(string currentPosition = "")
        {
            Console.Clear();

            if(currentPosition == "MainMenu")
            {
                UpdateConsoleView.UpdateView("Not Available");
                Console.ReadKey();
                Environment.Exit(1);
            }
            

            Console.SetCursorPosition(18, 7);
            Console.WriteLine("Work in progress");
            Console.SetCursorPosition(18, 8);
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();

            if (currentPosition == "MainMenu")
            {
                
                Console.Clear();
                MainMenu main = new MainMenu();
            }
            else
            {
                UpdateConsoleView.UpdateView(currentPosition);
            }
           
        }
    }
}
