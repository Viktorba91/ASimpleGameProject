using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.GameFolder.Functions
{
    public class ConsoleFunction
    {

        public static void SecondsDelay(int seconds)
        {
            int milliseconds = seconds * 1000;
            Thread.Sleep(milliseconds);
        }
        public static void ClearCurrentConsoleLine()
        {

        }
        public static void Clear2()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
        }
    }
}
