using ASimpleGameProject.GameFolder.Enemy;
using ASimpleGameProject.GameFolder.Menu;
using ASimpleGameProject.GameFolder.Player;
using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Levels
{
    internal class SpecialAtkView
    {
        public SpecialAtkView(EnemyCharacter enemy)
        {
            SpecialAtkAction(enemy);
        }
        private void SpecialAtkAction(EnemyCharacter enemy)
        {
            var specialAtk = new SpecialAttack();
            UpdateConsoleView.UpdateView("Battle");
            if(Game.Player.SpecialAtk.Count > 0)
            {
                if(Game.Player.SpecialAtk.Count >= 1)
                {
                    Game.Player.SpecialAtk.Add(new SpecialAttack("Go back", 0, 0, 0, 0));
                }
                specialAtk = SpecialAtkNavigation.MultipleChoice(false, Game.Player.SpecialAtk);
                if (Game.Player.CurrentMana < specialAtk.ManaCost)
                {
                    Console.WriteLine("\nYou don't have enough mana for that.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("You haven't learned any special attacks yet.");
                Console.ReadKey();
            }
            //int goback = Game.Player.SpecialAtk.FindIndex(n => n.Name == "Go back");
            //Game.Player.SpecialAtk.RemoveAt(goback);
            Battle battle = new Battle(enemy, specialAtk);
        }
    }
}
