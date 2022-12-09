using ASimpleGameProject.GameFolder.Levels;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Functions
{
    internal class BattleItem
    {
        string[] ConsumableChoice = {"Healing Potion", "Mana Potion   ", "Smoke Bomb", "Back" };
        
        public bool Consumables()
        {
           
            bool usedConsumable = false;
           
            int choice = Navigation.MultipleChoice(false, ConsumableChoice);
            
            //Healing Potion
            if (choice == 0)
            {
                usedConsumable = true;
                Game.Player.CurrentHealth += Game.Player.MaxHealth / 2;
                if(Game.Player.CurrentHealth > Game.Player.MaxHealth) Game.Player.CurrentHealth = Game.Player.MaxHealth;
            }
            else if (choice == 1) { }
            else if (choice == 2) { }
            else if (choice == 3) { }

            return usedConsumable;
        }
    }
}
