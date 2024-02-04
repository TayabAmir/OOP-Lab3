using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Calculator
    {
        public float num1;
        public float num2;

        public float addition()
        {
            return num1 + num2;
        }
        public float subtraction()
        {
            return num1 - num2;
        }
        public float multiplication()
        {
            return num1 * num2;
        }
        public float division()
        {
            return num1 / num2;
        }
    }
}
