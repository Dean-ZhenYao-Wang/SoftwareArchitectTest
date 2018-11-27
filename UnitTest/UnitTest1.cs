using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZYW.DTO;
using ZYW.Services.Service;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidVisa()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "4789081276381293",
                ExpiryDate = "082008"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "valid");
        }
        [TestMethod]
        public void NotExist()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber="4789081276381292",ExpiryDate="082008"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result= creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "does not exist");
        }
        [TestMethod]
        public void ValidMastercard()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "5789081276381293",
                ExpiryDate = "012011"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "valid");
        }
        [TestMethod]
        public void ValidAmex()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "342825897638134",
                ExpiryDate = "012011"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "valid");
        }
        [TestMethod]
        public void ValidJcb()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "3528258976381678",
                ExpiryDate = "012011"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "valid");
        }
        [TestMethod]
        public void InValidVisa()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "47890812381",
                ExpiryDate = "082008"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "invalid");
        }
        [TestMethod]
        public void InValidMastercard()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "5789081278129",
                ExpiryDate = "012011"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "invalid");
        }
        [TestMethod]
        public void InValidAmex()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "34282589381",
                ExpiryDate = "012011"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "invalid");
        }
        [TestMethod]
        public void InValidJcb()
        {
            CreditCardDTO creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "33282586388",
                ExpiryDate = "012011"
            };
            CreditCardService creditCardService = new CreditCardService();
            ValidationCreditCardDTO result = creditCardService.ValidationCreditCard(creditCardDTO);
            Assert.AreEqual(result.ValidationResult, "invalid");
        }
    }
}
