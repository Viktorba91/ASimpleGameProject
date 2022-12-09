using ASimpleGameProject.GameFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.Player
{
    internal class CreatePlayerCharacter
    {
        public string Name { get; private set; }
        public string ClassName { get; private set; }

        public CreatePlayerCharacter()
        {
            ClassName = ChooseClass();
            Name = EnterName();
        }

        public string ChooseClass()
        {
            int classId = 0;

            UpdateConsoleView.UpdateView("Menu");
            //Int 0 = Warrior, 1 = Wizard, 2 = Rogue
            string[] classSelection =
            {
                "<Warrior>", " <Wizard>", " <Rogue>",
            };

            while (true) 
            {
                classId = PlayerClassSelection.ChooseClass(true, classSelection);
                if (classId == 0) return "Warrior";
                else if (classId == 1) return "Wizard";
                else if (classId == 2) return "Rogue";
                else continue;
            }
            
            //Should never return this
            return " ";    

        }

        public string EnterName()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
    }
}
