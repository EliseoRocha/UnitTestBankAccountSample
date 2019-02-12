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
        private const double MaximumWithdrawAmount = 10000;

        public Account(string accNum)
        {
            if (string.IsNullOrWhiteSpace(accNum))
            {
                throw new ArgumentException($"{nameof(accNum)} cannot be null or whitespace");
            }

            AccountNumber = accNum;
        }

        public string AccountNumber { get; private set; }

        public string Owner { get; set; }

        public double Balance { get; private set; }

        /// <summary>
        /// Withdraws a specified positive amount from this bank account
        /// </summary>
        /// <param name="amt">The amount to withdraw</param>
        /// <exception cref="ArgumentException">Negative amounts throw exception</exception>
        /// <returns>Returns the new balance</returns>
        public double Withdraw(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} Must be positive!");
            }

            if (amt > Balance)
            {
                throw new ArgumentException("Overdrafting is not allowed!");
            }

            if (amt > MaximumWithdrawAmount)
            {
                throw new ArgumentException($"Withdraw amount cannot exceed {MaximumWithdrawAmount}");
            }
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
