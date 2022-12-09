using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASimpleGameProject.GameFolder;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.Items;

namespace ASimpleGameProject.Player
{
    public class PlayerCharacter
    {
        public string Name { get; private set; }
        public string ClassName { get; private set; }
        public int Level { get; set; } = 1;
        public int CurrentExperience { get; set; }
        public int NeededExperience { get; set; } = 500;
        public int CurrentHealth { get; set; } = 100;
        public int MaxHealth { get; set; } = 100;
        public int AttackPower { get; set; } = 15;
        public int MaxMana { get; set; } = 50;
        public int CurrentMana { get; set; } = 50;
        public int Agility { get; set; }
        public List<SpecialAttack> SpecialAtk {get; set;}
        public int Currency { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int BossCountdown { get; set; }
        public int MaxBossCountdown { get; set; }

        public PlayerCharacter(string className, string name)
        {
            Name = name;
            ClassName = className;
            SpecialAtk = new List<SpecialAttack>();
            Inventory = new List<Item>();
            EquippedWeapon = new Weapon("Sword", "Wooden Sword", 1, 1, 1, 1, 1);
            BossCountdown = 5;
            MaxBossCountdown = 5;
        }

        public Weapon EquipWeapon(Weapon weapon)
        {
            Console.Clear();
            Console.WriteLine(weapon.RequiredLevel);
            Console.ReadKey();
            if(Level >= weapon.RequiredLevel)
            {
                Weapon oldWeapon = EquippedWeapon;

                MaxHealth -= EquippedWeapon.Health;
                CurrentHealth -= EquippedWeapon.Health;
                AttackPower -= EquippedWeapon.Strength;
                MaxMana -= EquippedWeapon.Mana;
                CurrentMana -= EquippedWeapon.Mana;
                Agility -= EquippedWeapon.Agility;

                EquippedWeapon = weapon;
                MaxHealth += weapon.Health;
                CurrentHealth += weapon.Health;
                AttackPower += weapon.Strength;
                MaxMana += weapon.Mana;
                CurrentMana += weapon.Mana;
                Agility += weapon.Agility;

                Console.WriteLine($"Equipped {weapon.WeaponName}");
                return oldWeapon;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error equipping weapon");
                Console.ReadKey();
                return weapon;
            }
            
        }

        public void CheckInvDuplicates()
        {

        }
    }
}
