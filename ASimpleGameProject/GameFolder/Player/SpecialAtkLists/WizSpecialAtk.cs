using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Player.SpecialAtkLists
{
    internal class WizSpecialAtk
    {
        public List<SpecialAttack> specialAttacks = new List<SpecialAttack>();
        public WizSpecialAtk()
        {
            specialAttacks.Add(new SpecialAttack("Fireball", 50, 20, 50, 2));
            specialAttacks.Add(new SpecialAttack("Lightning Strike", 75, 25, 75, 4));
            specialAttacks.Add(new SpecialAttack("Pyroblast", 100, 50, 100, 6));

            specialAttacks.Add(new SpecialAttack("Go Back", 0, 0, 0, 0));
        }
    }
}
