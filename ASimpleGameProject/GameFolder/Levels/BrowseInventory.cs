using ASimpleGameProject.GameFolder.Functions;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    public class BrowseInventory
    {
        string[] ChooseInvCategory = {"Show all", "Weapons", "Consumables", "Back" };
        public BrowseInventory()
        {
            InventoryAction();
        }

        private void InventoryAction()
        {
            UpdateConsoleView.UpdateView();

            int choice = Navigation.MultipleChoice(false, ChooseInvCategory);
            if (choice == 0) { ShowInventory("All Items"); }
            else if (choice == 1) { ShowInventory("Weapons"); }
            else if (choice == 2) { ShowInventory("Consumables"); }
            else if (choice == 3) { Wilderness wilderness = new Wilderness(); }

        }

        private void ShowInventory(string categoryChoice)
        {
            List<Item> InventoryList = new List<Item>();
            InventoryList = SortList(categoryChoice);
            int choice = InventoryNavigation.InventoryChoice(false, InventoryList, categoryChoice);

            
            if (Game.Player.ClassName == "Warrior" && InventoryList.ElementAt(choice).ItemType == "Sword")
            {
                Console.Clear();
                WorkInProgress.NotAvailable("MainMenu");

                Console.WriteLine(InventoryList.ElementAt(choice).Weapon.RequiredLevel);
                Console.ReadKey();
                InventoryList.ElementAt(choice).Weapon = Game.Player.EquipWeapon(InventoryList.ElementAt(choice).Weapon);
            }
            else if (categoryChoice == "Consumables" && InventoryList.ElementAt(choice).ItemName == "Healing Potion")
            {
                if (InventoryList.ElementAt(choice).ItemCount > 0)
                {
                    Game.Player.CurrentHealth += Game.Player.MaxHealth / 2;
                    if (Game.Player.CurrentHealth > Game.Player.MaxHealth) Game.Player.CurrentHealth = Game.Player.MaxHealth;
                }
            }
            else if (choice == InventoryList.Count - 1)
            {
                UpdateConsoleView.UpdateView();
                BrowseInventory browseInventory = new BrowseInventory();
            }

        }



        private List<Item> SortList(string category)
        {
            List<Item> StackList = new List<Item>();
            int itemCount = 0;

            foreach (var item in Game.Player.Inventory)
            {
                //Find duplicate
                bool isDuplicate = StackList.Any(x => x.ItemName == item.ItemName);

                //Find duplicate amount
                itemCount = Game.Player.Inventory.FindAll(x => x.ItemName == item.ItemName).Sum(s => s.ItemCount);

                if (isDuplicate)
                {
                    Console.WriteLine("Found dupe");
                }
                else
                {
                    if (category == "Consumables") 
                    {
                        if (!item.IsWeapon)
                        {
                            StackList.Add(new Item(item.ItemName, item.ItemType, itemCount, item.ItemPrice));
                        }
                    }
                    else if (category == "Weapons")
                    {
                        if (item.IsWeapon)
                        {
                            StackList.Add(new Item(item.ItemName, item.ItemType, itemCount, item.ItemPrice));
                        }
                    }
                    else
                    {
                        StackList.Add(new Item(item.ItemName, item.ItemType, itemCount, item.ItemPrice));
                    }
                }
            }
            Console.WriteLine("Press enter to see the stacked list.");
            //Console.ReadKey();

            //foreach (var item in StackList)
            //{
            //    Console.WriteLine("Name: " + item.ItemName + " Count: " + item.ItemCount);
            //}

            UpdateConsoleView.UpdateView();
            return StackList;
        }
    }
}
