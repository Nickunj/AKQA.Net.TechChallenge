using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQA.Services;
using AKQA.Services.Controllers;

namespace AKQA.Services.Tests.Controllers
{
    [TestClass]
    public class NumberTextConverterControllerTest
    {
        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_CorrectValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 123.45;
            string expectedString = "ONE HUNDRED TWENTY THREE DOLLARS AND FOURTY FIVE CENTS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_DollasValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 123;
            string expectedString = "ONE HUNDRED TWENTY THREE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_CentsValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 0.45;
            string expectedString = "FOURTY FIVE CENTS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_ZeroValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 0;
            string expectedString = "ZERO DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_InvalidValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = double.NaN;
            string expectedString = "Currency value is empty or invalid.\r\nParameter name: numericValue";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_OneDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 1;
            string expectedString = "ONE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_TwoDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 12;
            string expectedString = "TWELVE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_ThreeDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 123;
            string expectedString = "ONE HUNDRED TWENTY THREE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_FourDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 1234;
            string expectedString = "ONE THOUSAND TWO HUNDRED THIRTY FOUR DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_FiveDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 12345;
            string expectedString = "TWELVE THOUSAND THREE HUNDRED FOURTY FIVE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_SixDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 123456;
            string expectedString = "ONE HUNDRED TWENTY THREE THOUSAND FOUR HUNDRED FIFTY SIX DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_SevenDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 1234567;
            string expectedString = "ONE MILLION TWO HUNDRED THIRTY FOUR THOUSAND FIVE HUNDRED SIXTY SEVEN DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_EightDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 12345678;
            string expectedString = "TWELVE MILLION THREE HUNDRED FOURTY FIVE THOUSAND SIX HUNDRED SEVENTY EIGHT DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_NineDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 123456789;
            string expectedString = "ONE HUNDRED TWENTY THREE MILLION FOUR HUNDRED FIFTY SIX THOUSAND SEVEN HUNDRED EIGHTY NINE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_TenDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 1234567890;
            string expectedString = "ONE BILLION TWO HUNDRED THIRTY FOUR MILLION FIVE HUNDRED SIXTY SEVEN THOUSAND EIGHT HUNDRED NINETY DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_ElevenDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 12345678901;
            string expectedString = "TWELVE BILLION THREE HUNDRED FOURTY FIVE MILLION SIX HUNDRED SEVENTY EIGHT THOUSAND NINE HUNDRED ONE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_TwelveDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 123456789012;
            string expectedString = "ONE HUNDRED TWENTY THREE BILLION FOUR HUNDRED FIFTY SIX MILLION SEVEN HUNDRED EIGHTY NINE THOUSAND TWELVE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_ThirteenDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 1234567890123;
            string expectedString = "ONE TRILLION TWO HUNDRED THIRTY FOUR BILLION FIVE HUNDRED SIXTY SEVEN MILLION EIGHT HUNDRED NINETY THOUSAND ONE HUNDRED TWENTY THREE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_FourteenDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 12345678901234;
            string expectedString = "TWELVE TRILLION THREE HUNDRED FOURTY FIVE BILLION SIX HUNDRED SEVENTY EIGHT MILLION NINE HUNDRED ONE THOUSAND TWO HUNDRED THIRTY FOUR DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_FifteenDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 123456789012345;
            string expectedString = "ONE HUNDRED TWENTY THREE TRILLION FOUR HUNDRED FIFTY SIX BILLION SEVEN HUNDRED EIGHTY NINE MILLION ONE THOUSAND TWO THOUSAND THREE HUNDRED FOURTY FIVE DOLLARS";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void Test_Api_NumberTextConvertedController_GetCurrencyWordConversion_When_SixteenDigitValue_provided()
        {
            // Arrange
            NumberTextConverterController controller = new NumberTextConverterController();
            double testValue = 1234567890123456;
            string expectedString = "Too big number. This function supports a value upto 15 digits.";
            string resultString = string.Empty;

            // Act
            var result = controller.Get(testValue);
            resultString = result.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsInstanceOfType(result.Content, typeof(StringContent));
            Assert.AreEqual(expectedString, resultString);
        }
    }
}
