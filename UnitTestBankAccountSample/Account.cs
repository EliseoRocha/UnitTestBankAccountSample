using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBankAccountSample
{
    /// <summary>
    /// Represents a simple checking account at a bank.
    /// </summary>
    public class Account
    {
        public Account(string accNum)
        {
            AccountNumber = accNum;
        }

        public string AccountNumber { get; private set; }

        public string Owner { get; set; }

        public double Balance { get; private set; }

        /// <summary>
        /// Withdraws a specified amount from this bank account
        /// </summary>
        /// <param name="amt">The amount to withdraw</param>
        /// <returns>Returns the new balance</returns>
        public double Withdraw(double amt)
        {
            //Ensure there is money to be withdrawn
            //Add a limit to withdrawl
            //Ensure amt is positive

            Balance -= amt;
            return Balance;
        }

        /// <summary>
        /// Deposites a specified amount to this bank account
        /// </summary>
        /// <param name="amt">The amount to deposit</param>
        /// <returns>Returns the new balance</returns>
        public double Deposit(double amt)
        {
            Balance += amt;
            return Balance;
        }
    }
}
