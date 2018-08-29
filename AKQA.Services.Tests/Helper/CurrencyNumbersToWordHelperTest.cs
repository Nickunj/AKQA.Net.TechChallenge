using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQA.Services;
using AKQA.Services.Controllers;
using AKQA.Services.Helper;
namespace AKQA.Services.Tests.Helper
{
    [TestClass]
    public class CurrencyNumbersToWordHelperTest
    {
        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_CorrectValue_provided()
        {
            // Arrange
            string testValue = "123.45";
            string expectedString = "ONE HUNDRED TWENTY THREE DOLLARS AND FOURTY FIVE CENTS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper(); 
            

            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_DollasValue_provided()
        {
            // Arrange
            string testValue = "123.00";
            string expectedString = "ONE HUNDRED TWENTY THREE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_CentsValue_provided()
        {
            // Arrange
            string testValue = "0.45";
            string expectedString = "FOURTY FIVE CENTS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_ZeroValue_provided()
        {
            // Arrange
            string testValue = "0";
            string expectedString = string.Empty;
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_InvalidValue_provided()
        {
            // Arrange
            string testValue = string.Empty;
            string expectedString = string.Empty;
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_OneDigitValue_provided()
        {
            // Arrange
            string testValue = "1.00";
            string expectedString = "ONE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_TwoDigitValue_provided()
        {
            // Arrange
            string testValue = "12.00";
            string expectedString = "TWELVE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_ThreeDigitValue_provided()
        {
            // Arrange
            string testValue = "123.00";
            string expectedString = "ONE HUNDRED TWENTY THREE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_FourDigitValue_provided()
        {
            // Arrange
            string testValue = "1234.00";
            string expectedString = "ONE THOUSAND TWO HUNDRED THIRTY FOUR DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_FiveDigitValue_provided()
        {
            // Arrange
            string testValue = "12345.00";
            string expectedString = "TWELVE THOUSAND THREE HUNDRED FOURTY FIVE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_SixDigitValue_provided()
        {
            // Arrange
            string testValue = "123456.00";
            string expectedString = "ONE HUNDRED TWENTY THREE THOUSAND FOUR HUNDRED FIFTY SIX DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_SevenDigitValue_provided()
        {
            // Arrange
            string testValue = "1234567.00";
            string expectedString = "ONE MILLION TWO HUNDRED THIRTY FOUR THOUSAND FIVE HUNDRED SIXTY SEVEN DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_EightDigitValue_provided()
        {
            // Arrange
            string testValue = "12345678.00";
            string expectedString = "TWELVE MILLION THREE HUNDRED FOURTY FIVE THOUSAND SIX HUNDRED SEVENTY EIGHT DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_NineDigitValue_provided()
        {
            // Arrange
            string testValue = "123456789.00";
            string expectedString = "ONE HUNDRED TWENTY THREE MILLION FOUR HUNDRED FIFTY SIX THOUSAND SEVEN HUNDRED EIGHTY NINE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_TenDigitValue_provided()
        {
            // Arrange
            string testValue = "1234567890.00";
            string expectedString = "ONE BILLION TWO HUNDRED THIRTY FOUR MILLION FIVE HUNDRED SIXTY SEVEN THOUSAND EIGHT HUNDRED NINETY DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_ElevenDigitValue_provided()
        {
            // Arrange
            string testValue = "12345678901.00";
            string expectedString = "TWELVE BILLION THREE HUNDRED FOURTY FIVE MILLION SIX HUNDRED SEVENTY EIGHT THOUSAND NINE HUNDRED ONE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_TwelveDigitValue_provided()
        {
            // Arrange
            string testValue = "123456789012.00";
            string expectedString = "ONE HUNDRED TWENTY THREE BILLION FOUR HUNDRED FIFTY SIX MILLION SEVEN HUNDRED EIGHTY NINE THOUSAND TWELVE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_ThirteenDigitValue_provided()
        {
            // Arrange
            string testValue = "1234567890123.00";
            string expectedString = "ONE TRILLION TWO HUNDRED THIRTY FOUR BILLION FIVE HUNDRED SIXTY SEVEN MILLION EIGHT HUNDRED NINETY THOUSAND ONE HUNDRED TWENTY THREE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_FourteenDigitValue_provided()
        {
            // Arrange
            string testValue = "12345678901234.00";
            string expectedString = "TWELVE TRILLION THREE HUNDRED FOURTY FIVE BILLION SIX HUNDRED SEVENTY EIGHT MILLION NINE HUNDRED ONE THOUSAND TWO HUNDRED THIRTY FOUR DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_FifteenDigitValue_provided()
        {
            // Arrange
            string testValue = "123456789012345.00";
            string expectedString = "ONE HUNDRED TWENTY THREE TRILLION FOUR HUNDRED FIFTY SIX BILLION SEVEN HUNDRED EIGHTY NINE MILLION ONE THOUSAND TWO THOUSAND THREE HUNDRED FOURTY FIVE DOLLARS";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();


            // Assert
            Assert.IsNotNull(resultString);
            Assert.IsInstanceOfType(resultString, typeof(string));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Api_CurrencyNumbersToWordHelper_GetCurrencyWordConversion_When_SixteenDigitValue_provided()
        {
            // Arrange
            string testValue = "1234567890123456.00";
            string resultString = string.Empty;

            // Act
            resultString = CurrencyNumbersToWordHelper.ConvertToWords(testValue).ToUpper();
        }
    }
}
