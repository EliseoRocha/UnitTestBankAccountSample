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
        private const double initialBalance = 100;

        [TestInitialize] //This is an Attribute, Run this before every single test
        public void TestInit()
        {
            acc = new Account("JOE");
            //Give account starting balance
            acc.Deposit(initialBalance);
        }

        [TestMethod()]
        [DataRow(10)]
        [DataRow(initialBalance)] //Withdraw all funds
        [DataRow(1.55)]
        [TestCategory("Withdraw")]
        public void Withdraw_ValidAmmount_FromBalance(double withdrawAmount)
        {
            //AAA Pattern (Arrange, Act, Assert)
            //Arrange
            double startingBalance = acc.Balance;
            double expected = startingBalance - withdrawAmount;

            //Act
            double newBalance = acc.Withdraw(withdrawAmount);

            //Assert
            Assert.AreEqual(expected, acc.Balance);
            Assert.AreEqual(expected, newBalance);
        }

        [TestMethod]
        [DataRow(initialBalance + 1)] //Overdrawing by $1
        [DataRow(10000.01)] //Exceeding the limit
        [TestCategory("Withdraw")]
        public void Withdraw_InvalidAmount_FromBalance(double withdrawAmount)
        {
            //Arrange

            //Asser => Act
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
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

        [TestMethod]
        [DataRow("JOE")]
        [DataRow("1234567890123")]
        [TestCategory("Constructors")]
        [Priority(1)]
        public void ConstructAccount_WithValidId(string accountNo)
        {
            Account myAcc = new Account(accountNo);
            Assert.AreEqual(accountNo, myAcc.AccountNumber);
        }

        [TestMethod]
        [DataRow("    ")]
        [DataRow(null)]
        [DataRow("                                                 ")]
        public void ConstructAccount_WithInvalidId_ThrowsArgumentException(string accNo)
        {
            Assert.ThrowsException<ArgumentException>(() => new Account(accNo));
        }
    }
}