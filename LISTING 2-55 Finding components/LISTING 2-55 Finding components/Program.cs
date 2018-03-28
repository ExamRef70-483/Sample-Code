using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_55_Finding_components
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

    public class BankAccount : IAccount
    {
        protected decimal balance = 0;

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

            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            List<Type> AccountTypes = new List<Type>();

            foreach ( Type t in thisAssembly.GetTypes() )
            {
                if (t.IsInterface)
                    continue;

                if(typeof(IAccount).IsAssignableFrom(t))
                {
                    AccountTypes.Add(t);
                }
            }

            foreach (Type t in AccountTypes)
                Console.WriteLine(t.Name);

            Console.ReadKey();
        }
    }
}
