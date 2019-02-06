using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestBankAccountSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBankAccountSample.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void Withdraw_ValidAmmount_FromBalance()
        {
            //AAA Pattern (Arrange, Act, Assert)
            //Arrange
            Account acc = new Account("Joe98499");
            double startingBalance = 100;
            double withdrawAmount = 10;
            double expected = startingBalance - withdrawAmount;
            acc.Deposit(startingBalance);

            //Act
            acc.Withdraw(withdrawAmount);

            //Assert
            Assert.AreEqual(expected, acc.Balance);
        }
    }
}