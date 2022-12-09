using ASimpleGameProject.GameFolder.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Menu
{
    public class SpecialAtkNavigation
    {
        //Arrow keys for input choice
        public static SpecialAttack MultipleChoice(bool canCancel,List<SpecialAttack> options)
        {
            const int startX = 8;
            const int startY = 8;
            const int optionsPerLine = 1;
            const int spacingPerLine = 10;

            int currentSelection = 0;
            SpecialAttack returnSelection = null;

            ConsoleKey key;

            Console.CursorVisible = false;

            UpdateConsoleView.UpdateView();

            do
            {
                //Console.Clear();

                for (int i = 0; i < options.Count; i++)
                {
                    Console.SetCursorPosition(startX + i % optionsPerLine * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Green;
                        returnSelection = options[currentSelection];
                    Console.Write(options[i].Name);

                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Count)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return null;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            int goBack = options.Count;
            options.RemoveAt(goBack -1);
            return returnSelection;
        }
    }
}
