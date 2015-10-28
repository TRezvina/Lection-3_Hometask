using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Calculator
    {
        #region Properties
        public double Val1 { get; set; }
        public double Val2 { get; set; }
        public string Operator { get; set; }
        public string ToCalculate { get; set; }
        #endregion

        #region Methods
        public double GetResult()
        {
            double result = 0; // Взяла double потому что при делении могут получиться дробные значения
            switch (Operator)
            {
                case "+":
                    {
                        result = Sum(Val1, Val2); //Сложение
                        return result;
                    }
                case "-":
                    {
                        result = Subtraction(Val1, Val2); // Вычитание
                        return result;
                    }
                case "*":
                    {
                        result = Multiplication(Val1, Val2); // Умножение
                        return result;
                    }
                case "/":
                    {
                        result = Division(Val1, Val2); // Деление
                        return result;
                    }
                default: Console.WriteLine("Incorrect operator: '{0}'!", Operator); break;
            }
            return result;
        }

        private double Sum(double val1, double val2)
        {
            return (val1 + val2);
        }

        private double Subtraction(double val1, double val2)
        {
            return (val1 - val2);
        }

        private double Multiplication(double val1, double val2)
        {
            return (val1 * val2);
        }

        private double Division(double val1, double val2)
        {
            return (val1 / val2);
        }

        public Calculator SetInitialValues()
        {
            Val1 = 0;
            Val2 = 0;
            Operator = "";
            ToCalculate = "";
            return new Calculator();
        }
        #endregion
    }




    class Program
    {
        static void Main(string[] args)
        {
            string val = "";
            string next = "Operand 1";
            double result = 0;

            Console.WriteLine("This calculator can perform adding, subtraction, division and multiplication.");
            Console.WriteLine("You can use '+', '-', '/', '*' and '=' for calculations.");
            Console.WriteLine("Press 'x' for exit, 'c' for clear.");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("");

            Calculator calc = new Calculator();
            do
            {

                if ((next == "Operator 1") || (next == "Operator 2"))
                    Console.Write("Enter operator: ");
                else
                    Console.Write("Enter value: ");


                val = Console.ReadLine();
                if (CheckIfExit(val))  // проверяем не введен ли 'x'
                { next = "Exit"; }
                else if (CheckIfClear(val)) // проверяем не введено ли 'c'
                {
                    calc.SetInitialValues();  //обнуляем все переменные
                    Console.WriteLine("");
                    Console.WriteLine("All entered data removed.");
                    Console.WriteLine("");
                    next = "Operand 1";
                }
                else
                {
                    calc.ToCalculate = string.Format("{0} {1}", calc.ToCalculate, val);
                    Console.WriteLine("");
                    switch (next)
                    {
                        case "Operand 1":
                            {
                                calc.Val1 = double.Parse(val);
                                next = "Operator 1";
                                continue;
                            }
                        case "Operator 1":
                            {
                                if (CheckIfOperator(val))
                                {
                                    calc.Operator = val;
                                    next = "Operand 2";
                                }
                                else
                                {
                                    Console.WriteLine("You entered incorrect operator: '{0}'!", val);
                                }
                                continue;
                            }
                        case "Operand 2":
                            {
                                calc.Val2 = double.Parse(val);
                                result = calc.GetResult();
                                next = "Operator 2";
                                continue;
                            }
                        case "Operator 2":
                            {
                                if (val == "=")
                                {
                                    Console.WriteLine("{0} {1}", calc.ToCalculate, result);
                                    Console.WriteLine("");
                                    calc.SetInitialValues();
                                    next = "Operand 1";

                                }
                                else if (CheckIfOperator(val))  // проверяем является ли введённое значение оператором (+, -, *, /)
                                {
                                    calc.Val1 = result;
                                    next = "Operand 2";

                                }
                                else
                                {
                                    Console.WriteLine("You entered incorrect operator: '{0}'!", val);

                                }
                                calc.Operator = val;
                                continue;
                            }
                    }

                }

            }
            while (next != "Exit");

            return;

        }

        public static bool CheckIfExit(string val)
        {
            if (val == "x")
                return true;
            else
                return false;
        }

        public static bool CheckIfClear(string val)
        {
            if (val == "c")
                return true;
            else
                return false;
        }

        public static bool CheckIfOperator(string val)
        {
            List<string> L = new List<string>();
            L.Add("+");
            L.Add("-");
            L.Add("/");
            L.Add("*");
            if (L.Contains(val))
                return true;
            else
                return false;
        }
    }
}

