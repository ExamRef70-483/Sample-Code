using System;

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

        private decimal _balance = 0;

        bool IAccount.WithdrawFunds(decimal amount)
        {
            if (_balance < amount)
            {
                return false;
            }
            _balance = _balance - amount;
            return true;
        }

        void IAccount.PayInFunds(decimal amount)
        {
            _balance = _balance + amount;
        }

        decimal IAccount.GetBalance()
        {
            return _balance;
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
