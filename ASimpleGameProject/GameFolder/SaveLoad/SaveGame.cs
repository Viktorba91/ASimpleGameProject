using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.Menu;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ASimpleGameProject.GameFolder.Levels;

namespace ASimpleGameProject.GameFolder.SaveLoad
{
    internal class SaveGame
    {
        private string[] GameSlot = { "Slot 1", "Slot 2", "Slot 3", "Go Back" };

        public SaveGame(PlayerCharacter player)
        {
            SaveGameView(player);
        }
        private void SaveGameView(PlayerCharacter player)
        {

            Console.Clear();
            int choice = Navigation.MultipleChoice(false, GameSlot);

            string playerData = ToBase64(player);
            //EncodeTo64(playerData);
            Console.Clear();

            if (choice != 3)
            {
                SaveToFile(choice, playerData);
                Console.Clear();
                Console.WriteLine("Saved game to slot " + choice + 1);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Town town = new Town();
            }
            else
            {
                Town town = new Town();
            }
        }
        private string ToBase64(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            byte[] bytes = Encoding.Default.GetBytes(json);

            return Convert.ToBase64String(bytes);
        }
        //private string EncodeTo64(string toEncode)
        //{
        //    byte[] toEncodeAsBytes
        //          = Encoding.ASCII.GetBytes(toEncode);
        //    string returnValue
        //          = Convert.ToBase64String(toEncodeAsBytes);
        //    return returnValue;
        //}

        //Save encrypted player data in string format to current slot file:
        private void SaveToFile(int slotNum, string playerData)
        {
            switch (slotNum)
            {
                case 0: 
                    File.WriteAllTextAsync("data.txt", playerData);
                    break;
                case 1: 
                    File.WriteAllTextAsync("data1.txt", playerData);
                    break;
                case 2:
                    File.WriteAllTextAsync("data2.txt", playerData);
                    break;
            }
            
        }

    }
}
