using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Player.SpecialAtkLists
{
    public class WarSpecialAtk
    {
        public List<SpecialAttack> specialAttacks = new List<SpecialAttack>();

        public WarSpecialAtk()
        {
            specialAttacks.Add(new SpecialAttack("Charge", 30, 15, 50, 2));
            specialAttacks.Add(new SpecialAttack("Heroic Strike", 50, 25, 75, 3));
            specialAttacks.Add(new SpecialAttack("Execute", 75, 50, 75, 4));
            
            specialAttacks.Add(new SpecialAttack("Go Back", 0, 0, 0, 0));
        }
        
    }
}
