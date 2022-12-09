using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.GameFolder.Player.SpecialAtkLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class ClassTrainer
    {
        public ClassTrainer()
        {
            SpecialAttack userChoice = new SpecialAttack();
            List<SpecialAttack> unlearnedSpecialAtks = new List<SpecialAttack>();

            //Warrior
            if (Game.Player.ClassName == "Warrior")
            {
                WarSpecialAtk warSpecialList = new WarSpecialAtk();
                foreach (var atk in warSpecialList.specialAttacks)
                {
                    //Check if Player has already learned any skills
                    if (!Game.Player.SpecialAtk.Any(n => n.Name == atk.Name))
                    {
                        unlearnedSpecialAtks.Add(atk);
                    }
                }
            }
            //Wizard
            else if(Game.Player.ClassName == "Wizard")
            {
                WizSpecialAtk wizSpecialList = new WizSpecialAtk();
                foreach (var atk in wizSpecialList.specialAttacks)
                {
                    //Check if Player has already learned any skills
                    if (!Game.Player.SpecialAtk.Any(n => n.Name == atk.Name))
                    {
                        unlearnedSpecialAtks.Add(atk);
                    }
                }
            }
            //Rogue
            else
            {

            }

            userChoice = ClassTrainerNavigation.MultipleChoice(false, unlearnedSpecialAtks);
            
            if(Game.Player.Currency >= userChoice.LearnSkillCost && Game.Player.Level >= userChoice.LevelRequired)
            {
                if (userChoice.Name != "Go Back")
                {
                    Game.Player.SpecialAtk.Add(userChoice);
                    Console.WriteLine($"\nLearned {userChoice.Name}");
                    Game.Player.Currency -= userChoice.LearnSkillCost;
                    Console.ReadKey();
                }
            }
            else if (Game.Player.Level < userChoice.LevelRequired || Game.Player.Currency < userChoice.LearnSkillCost)
            {
                Console.WriteLine("\nNot enough money or high enough level to learn skill");
                Console.ReadKey();
            }

            Town town = new Town();




        }
    }
}
