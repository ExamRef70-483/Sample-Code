using System;
using System.Collections.Generic;

namespace LISTING_2_40_Typed_IComparable
{
    public interface IAccount : IComparable<IAccount>
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

        public int CompareTo(IAccount account)
        {
            // if we are being compared with a null object we are definitely after it
            if (account == null) return 1;

            // use the balance value as the basis of the comparison
            return this.balance.CompareTo(account.GetBalance());
        }

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create 20 accounts with random balances
            List<IAccount> accounts = new List<IAccount>();
            Random rand = new Random(1);
            for (int i = 0; i < 20; i++)
            {
                IAccount account = new BankAccount(rand.Next(0, 10000));
                accounts.Add(account);
            }

            // Sort the accounts
            accounts.Sort();

            // Display the sorted accounts
            foreach (IAccount account in accounts)
            {
                Console.WriteLine(account.GetBalance());
            }

            Console.ReadKey();
        }
    }
}
