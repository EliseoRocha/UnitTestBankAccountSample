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
        private Account acc;

        [TestInitialize] //This is an Attribute, Run this before every single test
        public void TestInit()
        {
            acc = new Account("JOE");
            //Give account starting balance
            acc.Deposit(100);
        }

        [TestMethod()]
        public void Withdraw_ValidAmmount_FromBalance()
        {
            //AAA Pattern (Arrange, Act, Assert)
            //Arrange
            double startingBalance = acc.Balance;
            double withdrawAmount = 10;
            double expected = startingBalance - withdrawAmount;

            //Act
            acc.Withdraw(withdrawAmount);

            //Assert
            Assert.AreEqual(expected, acc.Balance);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //DO NOT USE ExpectedException
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            //Arrange
            double withdrawAmount = -5;

            //Assert => Act
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }
    }
}