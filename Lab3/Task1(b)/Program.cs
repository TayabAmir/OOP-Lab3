
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_b_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt,amount=0;
            ATM account = new ATM();
            do
            {
                Console.WriteLine("Enter 1 to open ATM Account");
                Console.WriteLine("Enter 2 to deposit money");
                Console.WriteLine("Enter 3 to withdraw money");
                Console.WriteLine("Enter 4 to check balance");
                Console.WriteLine("Enter 5 to see Transaction History");
                Console.WriteLine("Enter 0 to exit");
                opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    account.initializeAccount();
                    Console.WriteLine("Your account is initialized with 100 rupees");
                    Console.ReadKey();

                }
                else if (opt == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the amount you want to deposit: ");
                    amount = int.Parse(Console.ReadLine());
                    if (amount > 0)
                    {
                        account.depositMoney(amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Deposit");
                    }
                    Console.ReadKey();
                }
                else if (opt == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the amount you want to withdraw: ");
                    amount = int.Parse(Console.ReadLine());
                    account.withdrawMoney(amount);
                    Console.ReadKey();
                }
                else if (opt == 4)
                {
                    Console.Clear();
                    account.checkBalance();
                    Console.ReadKey();
                }
                else if(opt==5)
                {
                    Console.Clear();
                    Console.WriteLine("<-------------------------Transaction History------------------------>");
                    account.transactionHistory();
                    Console.ReadKey();
                }
            } while (opt != 0);
        }
    }
}
