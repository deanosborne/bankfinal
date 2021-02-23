using Microsoft.VisualStudio.TestTools.UnitTesting;
using a3;
using a3.Forms;
using a3.Models;

using System;

namespace AccountTests
{
    [TestClass]
    public class AccountUnitTest
    {
        Omni o = new Omni();
        [TestMethod]
        public void WithdrawWorks()
        { 
            int balance = o.balance = 1;
            o.WithdrawMoney(1);
            int expected = balance - 1;
            int actual = 0;

            Assert.AreEqual(expected, actual);
        }
        [ExpectedException(typeof(AccountM.InsufficientFundsException))]
        [TestMethod]
        public void WithdrawFails()
        {
            int balance = o.balance = 0;
            o.WithdrawMoney(1);
        }
        [TestMethod]
        public void InterestWorks()
        {
            int balance = o.balance = 1000;
            o.CalculateInterest(4, 1000);
            int expected = balance + (balance * 4) / 100;
            int actual = 1040;

            Assert.AreEqual(expected, actual);
        }
        [ExpectedException(typeof(AccountM.InsufficientBalanceException))]
        [TestMethod]
        public void InterestFails()
        {
            int balance = o.balance = 92;
            o.CalculateInterest(4, 1000);
        }

    }
}
