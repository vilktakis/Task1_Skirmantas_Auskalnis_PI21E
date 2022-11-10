using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;

namespace Task1
{
    public class ConsoleText
    {
        Logic logic;
        string function;
        string cleanFunction;

        public ConsoleText()
        {
            logic = new Logic();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Steve's rational number calculator!!!");
            NewFuntion();
            Menu();
        }

        public void NewFuntion()
        {
            logic.DeleteNumber();
            Console.WriteLine("Please input the function you wish to calculate.\nPlease don't break the code, input without spaces and use only regular alphabet letters for rational numbers.\nYou will be asked to input rational numbers in the next step.");
            Console.Write("Your function: ");
            function = Console.ReadLine();
            var charsToRemove = new string[] { "(", ")", "*", "/", "+", "-", "=", ">", "<" };
            cleanFunction = function;
            foreach (var c in charsToRemove)
            {
                cleanFunction = cleanFunction.Replace(c, string.Empty);
            }
            Console.WriteLine("Please type in the value of rational numbers, value must by without spaces, non negative or zero denominator, example: 1/10");
            List<char> existing = new List<char>();
            foreach (var c in cleanFunction)
            {
                if (!existing.Contains(c))
                {
                    existing.Add(c);
                    ImputNumbers(c.ToString());
                }
            }
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Your function: " + function);
            var unique = new HashSet<char>(cleanFunction);
            foreach (var c in unique)
            {
                Console.WriteLine(c + ": " + logic.Output(c.ToString()));
            }
            Console.WriteLine("Type in the number of the option you wish to take:\n1: Calculate\n2: Change Number\n3: Change Function\n4: Quit");
            Console.Write("Option: ");
            string i = Console.ReadLine();
            switch (i)
            {
                case "1":
                    logic.FunctionString(function);
                    Console.WriteLine(logic.Calculate(function));
                    Console.ReadLine();
                    Menu();
                    break;
                case "2":
                    Console.Write("Which number you wish to change: ");
                    string i1 = Console.ReadLine();
                    ChangeNumber(i1);
                    Menu();
                    break;
                case "3":
                    NewFuntion();
                    Menu();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Wrong command please try again.");
                    Menu();
                    break;
            }
        }

        public void ImputNumbers(string name)
        {
            Console.Write(name + ": ");
            string number = Console.ReadLine();
            if (!logic.Input(number, name))
            {
                Console.WriteLine("Wrong format!!! Try again");
                ImputNumbers(name);
            }
        }

        public void ChangeNumber(string name)
        {
            Console.Write(name + ": ");
            string number = Console.ReadLine();
            if (!logic.ChangeNumber(number, name))
            {
                Console.WriteLine("Wrong format!!! Try again");
                ImputNumbers(name);
            }
        }
    }
}
