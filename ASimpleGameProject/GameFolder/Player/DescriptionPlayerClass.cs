using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.Player
{
    internal class DescriptionPlayerClass
    {
        public static void ClassDescription(int classId)
        {
            //Warrior
            if (classId == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("        ");
                Console.Write("  The Warrior is a tough melee fighter who     " +
                    "\n          prefers static damage with a big health pool.\n");
                Console.WriteLine("\n          Warriors favours Health and Strength bonuses.");
            }
            //Wizard
            else if (classId == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("        ");
                Console.Write("  The Wizard use spells to overpower foes      " +
                    "\n          who stand in his way.                        \n");
                Console.WriteLine("\n          Wizards favour Mana bonus.                        ");
            }
            //Rogue
            else if (classId == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("        ");
                Console.Write("  The Rogue is sneaky and rely on critical hits " +
                    "\n          to burst the opponents down.                    \n");
                Console.WriteLine("\n          Rogues favours Agility bonus.                   ");
            }

        }
    }
}
