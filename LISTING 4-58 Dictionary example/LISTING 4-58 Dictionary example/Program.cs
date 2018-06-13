using System;
using System.Collections.Generic;

namespace LISTING_4_58_Dictionary_example
{
    class Program
    {
        class BankAccount
        {
            public int AccountNo { get; set; }
            public string Name { get; set; }
            public decimal Balance { get; set; }

            public override string ToString()
            {
                return string.Format("No:{0} Name:{1} Balance:{2}",
                    AccountNo, Name, Balance);
            }
        }

        static void Main(string[] args)
        {
            BankAccount a1 = new BankAccount { AccountNo = 1, Name = "Rob Miles" };
            BankAccount a2 = new BankAccount { AccountNo = 2, Name = "Immy Brown" };

            Dictionary<int, BankAccount> bank = new Dictionary<int, BankAccount>();

            bank.Add(a1.AccountNo, a1);
            bank.Add(a2.AccountNo, a2);

            Console.WriteLine(bank[1]);

            if (bank.ContainsKey(2))
                Console.WriteLine("Account located");

            Console.ReadKey();
        }
    }
}
