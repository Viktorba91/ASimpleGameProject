using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ASimpleGameProject.Player;
using ASimpleGameProject.Items;
using System.IO;

namespace ASimpleGameProject.GameFolder.SaveLoad
{
    internal class LoadGame
    {
        private string dataString { get; set; }
        private string[] GameSlot = { "Slot 1", "Slot 2", "Slot 3", "Go Back" };
        private string[] FileSlotPath = {"data.txt", "data1.txt", "data2.txt" };

        public LoadGame()
        {
            GameFileScreen();
        }
        private void GameFileScreen()
        {
            Console.Clear();
            CheckFiles();
            int choice = Navigation.MultipleChoice(false, GameSlot);
            
                if (choice != 3)
            {
                try
                {
                    switch (choice)
                    {
                        case 0:
                            dataString = System.IO.File.ReadAllText("data.txt");
                            break;
                        case 1:
                            dataString = System.IO.File.ReadAllText("data1.txt");
                            break;
                        case 2:
                            dataString = System.IO.File.ReadAllText("data2.txt");
                            break;
                    }
                    
                    PlayerCharacter player = new PlayerCharacter("", "");
                    player = FromBase64<PlayerCharacter>(dataString);
                    //IsValidFile(player);
                    Console.Clear();
                    if(player != null)
                    {
                        Game game = new Game(player);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Game slot is empty. Press any key to return to Main Menu.");
                        Console.ReadKey();
                        MainMenu menu = new MainMenu();
                    }
                    
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Could not load game from current slot.");
                    throw;
                    MainMenu menu = new MainMenu();
                }
                
                //List<Item> inventory = new List<Item>();
                
            }
            else if (choice == 3)
            {
                MainMenu menu = new MainMenu();
            }
        }
        public PlayerCharacter FromBase64<PlayerCharacter>(string base64Text)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64Text);

                string json = Encoding.Default.GetString(bytes);
                Console.Clear();
                //Console.WriteLine(json);
                //Console.ReadKey();
                return JsonConvert.DeserializeObject<PlayerCharacter>(json);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Corrupted Datafile. Shutting down.");
                Console.ReadKey();
                Environment.Exit(1);
                throw;
            }
            
        }
        private void CheckFiles()
        {
            bool fileExist; 
            foreach(string path in FileSlotPath)
            {
               fileExist = File.Exists(path);
                if (!fileExist)
                {
                    using (FileStream fs = File.Create(path)) ;
                    Console.WriteLine("Found missing file, and created " + path + " accordingly.");
                    Console.ReadKey();
                }
            }
        }
        //private void IsValidFile(PlayerCharacter player)
        //{
        //    try
        //    {
        //        if(player.Name != null)
        //        {

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
