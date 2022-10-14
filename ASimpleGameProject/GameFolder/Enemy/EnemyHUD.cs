using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Enemy
{
    internal class EnemyHUD
    {
        
        public EnemyHUD(EnemyCharacter enemy)
        {
            showEnemyHUD(enemy);
        }
        private void showEnemyHUD(EnemyCharacter enemy)
        {
            Console.SetCursorPosition(28, 15);
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("============================================");
            Console.SetCursorPosition(28, 16);
            Console.WriteLine($"|| {enemy.Name} |  Lv {enemy.Level} |");
            Console.SetCursorPosition(28, 17);
            Console.WriteLine("============================================");
            Console.SetCursorPosition(28, 18);
            Console.WriteLine($"|| HP: {enemy.CurrentHealth} / {enemy.MaxHealth} |");
            Console.SetCursorPosition(28, 19);
            Console.WriteLine("============================================\n");

            Console.ResetColor();
        }
    }
}
