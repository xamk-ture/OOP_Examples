using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Examples
{



    public class ExampleClass
    {
        public static int StaticVariable = 20; // Static variable

        public void MyMethod()
        {
            Console.WriteLine(ExampleClass.StaticVariable); // Accessible via class name
        }
    }

    public class BankAccount
    {
        private double balance; // Private variable, hidden from outside

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        public bool Withdraw(double amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}
