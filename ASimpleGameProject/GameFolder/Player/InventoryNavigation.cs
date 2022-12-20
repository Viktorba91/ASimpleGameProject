using ASimpleGameProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Player
{
    public class InventoryNavigation
    {
        //Arrow keys for input choice
        public static int InventoryChoice(bool canCancel, List<Item> options, string category)
        {
            int startX = 8;
            int startY = 6;
            const int optionsPerLine = 1;
            const int spacingPerLine = 10;

            //Adding "Back button" to the Inventory list:
            bool isBackButton = true;
            options.Add(new Item(isBackButton));

            int currentSelection = 0;
            ConsoleKey key;

            Console.CursorVisible = false;

            Console.SetCursorPosition(0, startY / optionsPerLine);
            Console.WriteLine($"-------------------- INVENTORY [{category}] -----------------------");
            startY = 8;
            Console.SetCursorPosition(startX % optionsPerLine * spacingPerLine + 12, startY / optionsPerLine);
            Console.Write("NAME");
            Console.SetCursorPosition(startX % optionsPerLine * spacingPerLine + 43, startY / optionsPerLine);
            Console.Write("AMOUNT");
            Console.SetCursorPosition(startX % optionsPerLine * spacingPerLine + 51, startY / optionsPerLine);
            Console.Write("ITEM TYPE");
            Console.SetCursorPosition(startX % optionsPerLine * spacingPerLine + 65, startY / optionsPerLine);
            Console.WriteLine("Level Req");

            startY = 10;

            do
            {
                //Console.Clear();

                for (int i = 0; i < options.Count; i++)
                {
                    Console.SetCursorPosition(startX + i % optionsPerLine * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Green;

                    //Check if item name is longer than 18 characters and adjust position:
                    if (options[i].ItemName.Length > 18)
                    {
                        Console.SetCursorPosition(1, startY + i / optionsPerLine);
                        Console.Write(options[i].ItemName);
                    }
                    else if (options[i].ItemName != "Back") Console.Write(options[i].ItemName);
                    // Adding "Go" to the "Back" text:
                    else Console.Write("\n         Go " + options[i].ItemName);
                   

                    Console.SetCursorPosition(startX + 37 + i % optionsPerLine * spacingPerLine, startY + i / optionsPerLine);

                    if (options[i].ItemName != "Back")
                    {
                        Console.Write(options[i].ItemCount);
                        Console.SetCursorPosition(startX + 42 + i % optionsPerLine * spacingPerLine, startY + i / optionsPerLine);
                        Console.Write(options[i].ItemType);
                        if (options[i].IsWeapon)
                        {
                            Console.SetCursorPosition(startX + 60 + i % optionsPerLine * spacingPerLine, startY + i / optionsPerLine);
                            Console.WriteLine(options[i].Weapon.RequiredLevel);
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            else currentSelection = options.Count() - 1;
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
                            else currentSelection = options.Count() - 1;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Count)
                                currentSelection += optionsPerLine;
                            else currentSelection = 0;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
