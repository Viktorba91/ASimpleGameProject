using ASimpleGameProject.GameFolder;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.Items
{
    public class Item
    {
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public int ItemCount { get; set; }
        public int ItemPrice { get; set; }
        public bool IsWeapon {get; set; }
        //public int RequiredLevel { get; set; }
        public Weapon Weapon { get; set; }

        public bool IsButton { get; set; }

        public Item()
        {

        }
        public Item(string name, string type, int count, int price)
        {
            IsWeapon = false;
            ItemName = name;
            ItemType = type;
            ItemCount = count;
            ItemPrice = price;
            if (ItemType == "Sword" || ItemType == "Staff" || ItemType == "Daggers")
            {
                IsWeapon = true;
            }
        }
        public Item(Weapon weapon)
        {
            IsWeapon = true;
            ItemName = weapon.WeaponName;
            ItemType = weapon.WeaponType;
            //RequiredLevel = weapon.RequiredLevel;
            ItemCount = 1;
            ItemPrice = weapon.RequiredLevel * 2;
            Weapon = weapon;
        }
        

        // For Inventory's "BACK" button
        public Item(bool isButton)
        {
            ItemName = "Back";
            IsButton = isButton;
        }
    }
}
