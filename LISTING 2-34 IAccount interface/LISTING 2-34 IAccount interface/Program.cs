using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_34_IAccount_interface
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

        bool IAccount.WithdrawFunds(decimal amount)
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

    class Program
    {
        static void Main(string[] args)
        {
            IAccount account = new BankAccount();
            account.PayInFunds(50);
            Console.WriteLine("Balance: {0}", account.GetBalance());

            Console.ReadKey();
        }
    }
}
