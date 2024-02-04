using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            char op; 
            Console.Write("Enter num1: ");
            calculator.num1 = float.Parse(Console.ReadLine());
            Console.Write("Enter num2: ");
            calculator.num2 = float.Parse(Console.ReadLine());
            Console.Write("Enter operation (+,-,*,/): ");
            op = char.Parse(Console.ReadLine());
            if(op == '+')
            {
                Console.WriteLine(calculator.addition());
            }
            if (op == '-')
            {
                Console.WriteLine(calculator.subtraction());
            }
            if (op == '*')
            {
                Console.WriteLine(calculator.multiplication());
            }
            if (op == '/')
            {
                Console.WriteLine(calculator.division());
            }
            Console.ReadKey();
        }
    }
}
