using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Player
{
    internal class PlayerHUD
    {
        private void ShowPlayerStats(PlayerCharacter player)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine($"|| Name: {player.Name} | Class: {player.ClassName} ||  Lv {player.Level} | Exp: {player.CurrentExperience} / {player.NeededExperience}  ||");
            Console.WriteLine("=================================================================");
            Console.WriteLine($"|| HP: {player.CurrentHealth} / {player.MaxHealth} ||  Mana: {player.CurrentMana} / {player.MaxMana} ||  Money: {player.Currency}");
            Console.WriteLine("=================================================================\n");
        }
        public void GetPlayerStats(PlayerCharacter player)
        {
            ShowPlayerStats(player);
        }
    }
}
