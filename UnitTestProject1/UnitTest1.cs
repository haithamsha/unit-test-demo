using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using utdemo;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert is handled by ExpectedException  
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 13;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Debit(debitAmount);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                // assert
                StringAssert.Contains(ex.Message, "amount");
                return;
            }

            Assert.Fail("Must thrwo Argument Out Of RangeException");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debit_WhenCustoemrNameNullOrEmpty_ShouldThrowArgumentNullExeption()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            BankAccount account = new BankAccount("", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert is handled by ExpectedException  

        }
    }
}
