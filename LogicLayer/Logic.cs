using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace LogicLayer
{
    public class Logic
    {
        public List<RationalNumber> rationalNumbers = new List<RationalNumber>();
        public List<RationalNumber> operations = new List<RationalNumber>();
        private int k = 0;
        public bool Input(string istream, string name)
        {
            int x = istream.IndexOf("/");

            if (x > 0)
            {
                int numerator;
                int denominator;

                bool y = Int32.TryParse(istream.Substring(0, x), out numerator);
                bool z = Int32.TryParse(istream.Substring(x + 1), out denominator);

                if (y && z)
                {
                    if (denominator > 0)
                    {
                        RationalNumber rationalNumber = new RationalNumber(numerator, denominator);
                        rationalNumber.name = name;
                        rationalNumbers.Add(rationalNumber);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string Output(string name)
        {
            RationalNumber rationalNumber = rationalNumbers.Find(x => x.name == name);
            string ostream = rationalNumber.numerator + "/" + rationalNumber.denominator;
            return ostream;
        }

        public bool ChangeNumber(string istream, string name)
        {
            int x = istream.IndexOf("/");

            if (x > 0)
            {
                int numerator;
                int denominator;

                bool y = Int32.TryParse(istream.Substring(0, x), out numerator);
                bool z = Int32.TryParse(istream.Substring(x + 1), out denominator);

                if (y && z)
                {
                    if (denominator > 0)
                    {
                        RationalNumber rationalNumber = new RationalNumber(numerator, denominator);
                        rationalNumber.name = name;
                        rationalNumbers[rationalNumbers.IndexOf(rationalNumbers.Find(a => a.name == name))] = rationalNumber;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void FunctionString(string function)
        {
            operations = new List<RationalNumber>();
            k = 0;
            if (CheckLenght(function))
            {
                function = Parentheses(function);
                if (CheckLenght(function))
                {
                    function = MultiplicationDivision(function);
                    if (CheckLenght(function))
                    {
                        function = AdditionSubtraction(function);
                        LastOperation(function);
                    }
                    else
                    {
                        LastOperation(function);
                    }
                }
                else
                {
                    LastOperation(function);
                }
            }
            else
            {
                LastOperation(function);
            }

            foreach (RationalNumber rationalNumber in operations)
            {
                Console.WriteLine(rationalNumber.name);
            }
        }

        public string Calculate(string function)
        {
            string ostream = "Function: " + function + "\n";
            for (int i = 0; i < operations.Count; i++)
            {
                ostream = ostream + i + ": " + Operation(operations[i].name, i) + "\n";
            }
            return ostream;
        }

        public string Operation(string name, int index)
        {
            string text = "";
            if (name.ElementAt(0) == '-')
            {
                if (Char.IsDigit(name.ElementAt(1)))
                {
                    operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(1))].Negative();
                    text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                }
                else
                {
                    operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(1))).Negative();
                    text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                }
            }
            else
            {
                switch (name.ElementAt(1))
                {
                    case '-':
                        if (Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Subtraction(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (Char.IsDigit(name.ElementAt(0)) && !Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Subtraction(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (!Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Subtraction(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Subtraction(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        break;
                    case '+':
                        if (Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Addition(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (Char.IsDigit(name.ElementAt(0)) && !Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Addition(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (!Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Addition(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Addition(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        break;
                    case '/':
                        if (Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Division(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (Char.IsDigit(name.ElementAt(0)) && !Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Division(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (!Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Division(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Division(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        break;
                    case '*':
                        if (Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Multiplication(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (Char.IsDigit(name.ElementAt(0)) && !Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = operations[(int)Char.GetNumericValue(name.ElementAt(0))].Multiplication(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else if (!Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Multiplication(operations[(int)Char.GetNumericValue(name.ElementAt(2))]);
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        else
                        {
                            operations[index] = rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Multiplication(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))));
                            text = name + " = " + operations[index].numerator + "/" + operations[index].denominator;
                        }
                        break;
                    case '>':
                        if (Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + operations[(int)Char.GetNumericValue(name.ElementAt(0))].More(operations[(int)Char.GetNumericValue(name.ElementAt(2))]).ToString();
                        }
                        else if (Char.IsDigit(name.ElementAt(0)) && !Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + operations[(int)Char.GetNumericValue(name.ElementAt(0))].More(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2)))).ToString();
                        }
                        else if (!Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).More(operations[(int)Char.GetNumericValue(name.ElementAt(2))]).ToString();
                        }
                        else
                        {
                            text = name + " is " + rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).More(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2)))).ToString();
                        }
                        break;
                    case '<':
                        if (Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + operations[(int)Char.GetNumericValue(name.ElementAt(2))].More(operations[(int)Char.GetNumericValue(name.ElementAt(0))]).ToString();
                        }
                        else if (!Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + operations[(int)Char.GetNumericValue(name.ElementAt(2))].More(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0)))).ToString();
                        }
                        else if (Char.IsDigit(name.ElementAt(0)) && !Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))).More(operations[(int)Char.GetNumericValue(name.ElementAt(0))]).ToString();
                        }
                        else
                        {
                            text = name + " is " + rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2))).More(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0)))).ToString();
                        }
                        break;
                    case '=':
                        if (Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + operations[(int)Char.GetNumericValue(name.ElementAt(0))].Equals(operations[(int)Char.GetNumericValue(name.ElementAt(2))]).ToString();
                        }
                        else if (Char.IsDigit(name.ElementAt(0)) && !Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + operations[(int)Char.GetNumericValue(name.ElementAt(0))].Equals(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2)))).ToString();
                        }
                        else if (!Char.IsDigit(name.ElementAt(0)) && Char.IsDigit(name.ElementAt(2)))
                        {
                            text = name + " is " + rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Equals(operations[(int)Char.GetNumericValue(name.ElementAt(2))]).ToString();
                        }
                        else
                        {
                            text = name + " is " + rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(0))).Equals(rationalNumbers.Find(x => x.name == Char.ToString(name.ElementAt(2)))).ToString();
                        }
                        break;
                    default:
                        text = "WTF!!!";
                        break;
                }
            }
            return text;
        }

        public string Parentheses(string function)
        {
            int index1 = -1;
            int index2 = -1;
            for (int i = 0; i < function.Length; i++)
            {
                if (function.ElementAt(i) == '(')
                {
                    index1 = i;
                }
                else if (function.ElementAt(i) == ')')
                {
                    index2 = i;
                }
                if (index1 != -1 && index2 != -1)
                {
                    int j = index2 - index1;
                    if (j > 4)
                    {
                        string insideFunction = function.Substring(index1 + 1, j - 1);

                        insideFunction = MultiplicationDivision(insideFunction);
                        if (CheckLenght(insideFunction))
                        {
                            insideFunction = AdditionSubtraction(insideFunction);
                            LastOperation(insideFunction);
                        }
                        else
                        {
                            LastOperation(insideFunction);
                        }

                        string newFunction = function.Replace(function.Substring(index1, j+1), k.ToString());
                        k = k + 1;

                        function = Parentheses(newFunction);

                        i = function.Length;
                    }
                    else
                    {
                        RationalNumber rationalNumber = new RationalNumber();
                        rationalNumber.name = function.Substring(index1 + 1, 3);

                        operations.Add(rationalNumber);

                        string newFunction = function.Replace(function.Substring(index1, 5), k.ToString());
                        k = k + 1;

                        function = Parentheses(newFunction);

                        i = function.Length;
                    }
                }
            }
            return function;
        }

        public string MultiplicationDivision(string function)
        {
            for (int i = 0; i < function.Length; i++)
            {
                if (function.ElementAt(i) == '/' || function.ElementAt(i) == '*')
                {
                    RationalNumber rationalNumber = new RationalNumber();
                    rationalNumber.name = function.Substring(i - 1 , 3);

                    operations.Add(rationalNumber);

                    string newFunction = function.Replace(function.Substring(i - 1, 3), k.ToString());
                    k = k + 1;

                    if (CheckLenght(newFunction))
                    {
                        function = MultiplicationDivision(newFunction);
                    }
                    else
                    {
                        function = newFunction;
                    }

                    i = function.Length;
                }
            }
            return function;
        }

        public string AdditionSubtraction(string function)
        {
            for (int i = 0; i < function.Length; i++)
            {
                if (function.ElementAt(i) == '-' || function.ElementAt(i) == '+')
                {
                    RationalNumber rationalNumber = new RationalNumber();
                    rationalNumber.name = function.Substring(i - 1, 3);

                    operations.Add(rationalNumber);

                    string newFunction = function.Replace(function.Substring(i - 1, 3), k.ToString());
                    k = k + 1;

                    if (CheckLenght(newFunction))
                    {
                        function = AdditionSubtraction(newFunction);
                    }
                    else
                    {
                        function = newFunction;
                    }

                    i = function.Length;
                }
            }
            return function;
        }

        public bool CheckLenght(string function)
        {
            if (function.Length < 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void LastOperation(string function)
        {
            RationalNumber rationalNumber = new RationalNumber();
            rationalNumber.name = function;

            operations.Add(rationalNumber);
        }

        public void DeleteNumber()
        {
            rationalNumbers = new List<RationalNumber>();
        }
    }
}