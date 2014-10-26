using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise1_BankAccount;

namespace UnitTestBankAccount {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TestCreateBankWithInvalidOverdraft() {
            CurrentAccount c = new CurrentAccount("Ac12345", -100);
        }

        [TestMethod]
        public void TestMakeDeposit() {
            CurrentAccount c = new CurrentAccount("Ac12345", 100);
            c.MakeDeposit(100);
            Assert.AreEqual(c.Balance, 100);
        }

        [TestMethod]
        public void TestMakeWithdrawal() {
            CurrentAccount c = new CurrentAccount("Ac12345", 100);
            c.MakeWithdrawal(50);
            Assert.AreEqual(c.Balance, -50);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestOverdraft() {
            CurrentAccount c = new CurrentAccount("Ac12345", 100);
            c.MakeDeposit(100);
            c.MakeWithdrawal(201);
            Assert.AreEqual(c.Balance, -1);
        }

        [TestMethod]
        public void TestTransactionHistory() {
           
        }
    }
}
