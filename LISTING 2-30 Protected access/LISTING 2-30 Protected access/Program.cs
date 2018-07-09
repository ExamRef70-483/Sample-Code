using System;

namespace LISTING_2_30_Protected_access
{
    class BankAccount
    {
        protected decimal _accountBalance = 0;

        public void PayInFunds(decimal amountToPayIn)
        {
            _accountBalance = _accountBalance + amountToPayIn;
        }

        public virtual bool WithdrawFunds(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _accountBalance)
                return false;

            _accountBalance = _accountBalance - amountToWithdraw;
            return true;
        }

        public decimal GetBalance()
        {
            return _accountBalance;
        }
    }

    class OverdraftAccount : BankAccount
    {
        decimal overdraftLimit = 100;

        public override bool WithdrawFunds(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _accountBalance + overdraftLimit)
                return false;

            _accountBalance = _accountBalance - amountToWithdraw;
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
