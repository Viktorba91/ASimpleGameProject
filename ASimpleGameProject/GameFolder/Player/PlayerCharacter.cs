using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASimpleGameProject.GameFolder;
using ASimpleGameProject.Items;

namespace ASimpleGameProject.Player
{
    internal class PlayerCharacter
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
        public int Currency { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon Weapon { get; set; }

        public PlayerCharacter(string className, string name)
        {
            Name = name;
            ClassName = className;
        }
    }
}
