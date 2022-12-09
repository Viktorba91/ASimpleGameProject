using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Enemy
{
    internal class EnemyCharacter
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }

        public EnemyCharacter()
        {
            EnemyGenerate(Game.Player, Game.isBoss);
        }
        private void EnemyGenerate(PlayerCharacter player, bool isBoss)
        {
            Random rnd = new Random();
           
            //Generate Name
            try
            {
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    string[] names = { };
                    if (isBoss)
                    {
                        names = File.ReadAllLines("Boss.txt");
                    }
                    else
                    {
                        names = File.ReadAllLines("Enemy.txt");
                    }
                    

                    int randomLineNum = rnd.Next(names.Length);

                    //Console.WriteLine(names[randomLineNum]);

                    Name = names[randomLineNum];
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Level = rnd.Next(player.Level - 5, player.Level + 5);
            if (Level < 1) Level = 1;

            MaxHealth = rnd.Next(player.Level * 2 + 100);
            CurrentHealth = MaxHealth;
            AttackPower = rnd.Next(player.Level * 2 + 20);
            if (isBoss)
            {
                MaxHealth = MaxHealth * 2;
                CurrentHealth = MaxHealth;
                AttackPower = Game.Player.AttackPower + AttackPower;
            }

        }
    }
    
}
