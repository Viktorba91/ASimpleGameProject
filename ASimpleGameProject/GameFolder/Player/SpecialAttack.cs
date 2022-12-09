using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Player
{
    public class SpecialAttack
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int ManaCost { get; set; }
        public int LearnSkillCost { get; set; }
        public int LevelRequired { get; set; }
        public SpecialAttack(string name, int damage, int manaCost, int learnSkillCost, int levelRequired)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
            LearnSkillCost = learnSkillCost;
            LevelRequired = levelRequired;
        }

        public SpecialAttack(string AtkWindow)
        {
            SpecialAtkAction();
        }
        public SpecialAttack()
        {

        }

        private void SpecialAtkAction()
        {
            
        }
    }
    
}
