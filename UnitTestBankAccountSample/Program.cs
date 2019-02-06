using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBankAccountSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account("abc");
            try
            {
                acc.Withdraw(-10);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine("I'm sorry, the amount you entered is not valid");
            }
            Console.ReadLine();
            
        }
    }
}
