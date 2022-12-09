using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.Items
{
    public class Weapon : Item
    {
        public string WeaponType { get;  set; }
        public string WeaponName { get;  set; }
        public int RequiredLevel { get; set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Mana { get; private set; }
        public int Agility { get; private set; }
        
        Random rnd = new Random();
        public Weapon()
        {
            
        }
        public Weapon(string weaponType, string name, int reqLvl, int hp, int str, int mp, int agi)
        {
            WeaponType = weaponType;
            WeaponName = name;
            RequiredLevel = reqLvl;
            Health = hp;
            Strength = str;
            Mana = mp;
            Agility = agi;
        }
        public Weapon(PlayerCharacter player) : base("Weapon","Weapon", 1, 1)
        {
            WeaponType = GenerateWeaponType();
            WeaponName = GenerateWeaponName(WeaponType);
            
            RequiredLevel = CalculateInteger(player);
            Health = CalculateInteger(player);
            Strength = CalculateInteger(player);
            Mana = CalculateInteger(player);
            Agility = CalculateInteger(player);
            
        }
        private string GenerateWeaponType()
        {
            string[] weaponType = { "Sword", "Staff", "Daggers" };
            int weaponTypeIndex = rnd.Next(weaponType.Length);
            WeaponType = weaponType[weaponTypeIndex];
            
            return WeaponType;
        }
        private string GenerateWeaponName(string weaponType)
        {
            string name = "";
            try
            {
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    string[] names = File.ReadAllLines($"{weaponType}.txt");

                    int randomLineNum = rnd.Next(names.Length);

                    Console.WriteLine(names[randomLineNum]);

                    name = names[randomLineNum];
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return name;
        }
        private int CalculateInteger(PlayerCharacter player)
        {
            int calculatedStat = 0;

            calculatedStat = rnd.Next(player.Level - 5, player.Level + 5);
            if (calculatedStat < 0) { calculatedStat = 1; }
            return calculatedStat;
        }
    }
}
