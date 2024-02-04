using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_b_
{
    internal class ATM
    {
        public int money;
        List<string> tHistory = new List<string>();

        public void initializeAccount()
        {
            money = 100;
            Console.WriteLine("Account Initialized");
        }
        public void depositMoney(int dAmount)
        {
            money += dAmount;
            tHistory.Add("You deposited " + dAmount + " pkr");
        }
        public void withdrawMoney(int wAmount)
        {
            if (wAmount <= money)
            {
                money -= wAmount;
                tHistory.Add("You withdraw " + wAmount + " pkr");
            }
            else
            {
                Console.WriteLine("Invalid Withdrawal");
            }
        }
        public void checkBalance()
        {
            Console.WriteLine("Your current balance is: " +  money);
        }
        public void transactionHistory() 
        {
             for(int i=0; i<tHistory.Count; i++)
            {
                Console.WriteLine(tHistory[i]);
            }    
        }
    }
}
