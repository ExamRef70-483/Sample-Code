using System;

namespace LISTING_2_29_Creating_accessor_methods
{

    class BankAccount
    {
        private decimal accountBalance = 0;

        public void PayInFunds(decimal amountToPayIn)
        {
            accountBalance = accountBalance + amountToPayIn;
        }

        public bool WithdrawFunds(decimal amountToWithdraw)
        {
            if (amountToWithdraw > accountBalance)
                return false;

            accountBalance = accountBalance - amountToWithdraw;
            return true;
        }

        public decimal GetBalance()
        {
            return accountBalance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount a = new BankAccount();
            Console.WriteLine("Pay in 50");
            a.PayInFunds(50);
            if (a.WithdrawFunds(10))
                Console.WriteLine("Withdrawn 10");
            Console.WriteLine("Account balance is: {0}", a.GetBalance());
            Console.ReadKey();
        }
    }
}
