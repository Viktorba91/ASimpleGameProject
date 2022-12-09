using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.Items;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class Shop
    {
        private List<Item> WeaponsForSale { get; set; }
        private PlayerCharacter Player { get; set; }
        private bool IsBuying = false;
        private string[] ShopCategory = {"Buy", "Sell", "Go back" };
        private string[] SubShopCategory = {"Consumables", "Weapons", "Go back" };
        private string[] Consumables = { "Healing Potion", "Mana Potion", "Go back" };
        private int Choice = 0;
        public Shop(PlayerCharacter player)
        {
            WeaponsForSale = new List<Item>();
            Player = player;
            ShopAction(Player);
        }
        private void ShopAction(PlayerCharacter player)
        {
            Console.Clear();
            UpdateConsoleView.UpdateView();

            Choice = Navigation.MultipleChoice(false, ShopCategory);
            switch (Choice)
            {
                case 0:
                    IsBuying = true;
                    BuyMenu();
                    break;
                case 1:
                    break;
                case 2: 
                    Tavern tavern = new Tavern();
                    break;
            }
        }
        private void BuyMenu()
        {
            UpdateConsoleView.UpdateView();
            Choice = Navigation.MultipleChoice(false, SubShopCategory);
            switch (Choice)
            {
                case 0:
                    ConsumableMenu();
                    break;
                case 1:
                    GenerateWeaponList();
                    BuyWeaponsMenu();
                    break;
                case 2:
                    ShopAction(Player);
                    break;
            }
        }
        private void ConsumableMenu()
        {
            Choice = Navigation.MultipleChoice(false, Consumables);
            if (Choice == 0 && Game.Player.Currency >= 15)
            {
                Game.Player.Currency -= 15;
                Game.Player.Inventory.Add(new Item("Healing Potion", "Consumable", 1, 1));
                Console.WriteLine("\n\nBought a healing potion.");
                Console.ReadKey();
                UpdateConsoleView.UpdateView("");
                ConsumableMenu();
            }
            else if (Choice == 2)
            {
                BuyMenu();
            }
        }
        private void BuyWeaponsMenu()
        {
            Console.Clear();
            UpdateConsoleView.UpdateView();
            //Class to navigate shop
            foreach (Item item in WeaponsForSale)
            {
                Console.WriteLine(item.ItemName);
            }
            Console.ReadKey();
            
        }
        private void GenerateWeaponList()
        {
            for (int i = 0; i < 5; i++)
            {
                Weapon weapon = new Weapon(Game.Player);
                Item itemWeapon = new Item(weapon);
                if (WeaponsForSale.Contains(weapon))
                {
                    i--;
                    continue;
                }
                WeaponsForSale.Add(itemWeapon);
            }
        }

    }
}
