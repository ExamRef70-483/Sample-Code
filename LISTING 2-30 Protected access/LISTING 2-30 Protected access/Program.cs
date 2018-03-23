using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_30_Protected_access
{
    class BankAccount
    {
        protected decimal accountBalance = 0;

        public void PayInFunds(decimal amountToPayIn)
        {
            accountBalance = accountBalance + amountToPayIn;
        }

        public virtual bool WithdrawFunds(decimal amountToWithdraw)
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

    class OverdraftAccount : BankAccount
    {
        decimal overdraftLimit = 100;

        public override bool WithdrawFunds(decimal amountToWithdraw)
        {
            if (amountToWithdraw > accountBalance + overdraftLimit)
                return false;

            accountBalance = accountBalance - amountToWithdraw;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OverdraftAccount a = new OverdraftAccount();
            a.PayInFunds(50);
            Console.WriteLine("Pay in 50");
            if (a.WithdrawFunds(60))
                Console.WriteLine("Withdrawn 60");
            Console.WriteLine("Account balance is: {0}", a.GetBalance());
            Console.ReadKey();
        }
    }
}
