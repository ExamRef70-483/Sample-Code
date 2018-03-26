using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_38_BankAccount_constructor
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

    public class BankAccount : IAccount
    {
        private decimal balance;

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

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }
    }

    public class BabyAccount : BankAccount, IAccount
    {
        public BabyAccount(int initialBalance) : base(initialBalance)
        {
        }

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
            IAccount a = new BankAccount(100);
            IAccount b = new BabyAccount(100);

            Console.ReadKey();
        }
    }
}
