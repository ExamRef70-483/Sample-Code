using System;

namespace LISTING_2_35_BabyAccount
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

    public class BabyAccount : IAccount
    {
        private decimal _balance = 0;

        bool IAccount.WithdrawFunds(decimal amount)
        {
            if (amount > 10)
            {
                return false;
            }
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
            IAccount b = new BabyAccount();
            b.PayInFunds(50);
            Console.WriteLine("Balance: {0}", b.GetBalance());

            Console.ReadKey();
        }
    }
}
