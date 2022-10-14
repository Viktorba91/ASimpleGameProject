using ASimpleGameProject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Enemy
{
    internal class GenerateEnemy
    {
        public EnemyCharacter EnemyGenerate(PlayerCharacter player)
        {
            Random rnd = new Random();
            EnemyCharacter enemy = new EnemyCharacter();

            //Generate Enemy name
            try
            {
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    string[] names = File.ReadAllLines("Enemy.txt");

                    int randomLineNum = rnd.Next(names.Length);

                    Console.WriteLine(names[randomLineNum]);

                    enemy.Name = names[randomLineNum];
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            enemy.Level = rnd.Next(player.Level - 5, player.Level + 5);
            if (enemy.Level < 1) enemy.Level = 1;

            enemy.MaxHealth = rnd.Next(1, player.Level * 2) + 100;
            enemy.AttackPower = rnd.Next(1, player.Level * 2) + 50;
            Console.WriteLine("Level " + enemy.Level + " enemy | " + enemy.MaxHealth + "HP | " + enemy.AttackPower + "Atk");

            return enemy;
        }
    }
}
