using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_37_The_base_method
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

    public class BankAccount : IAccount
    {
        private decimal balance = 0;

        public virtual bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        void IAccount.PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        decimal IAccount.GetBalance()
        {
            return balance;
        }
    }

    public class BabyAccount : BankAccount, IAccount
    {
        public override bool WithdrawFunds(decimal amount)
        {
            if (amount > 10)
            {
                return false;
            }
            else
            {
                return base.WithdrawFunds(amount);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAccount b = new BabyAccount();
            b.PayInFunds(50);
            if (b.WithdrawFunds(10))
                Console.WriteLine("Withdraw succeeded");
            else
                Console.WriteLine("Withdraw failed");

            Console.ReadKey();
        }
    }
}
