using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using AKQA.Services.Helper;
using AKQA.Services.Constants;
namespace AKQA.Services.Controllers
{
    /// <summary>
    /// This controller converts numeric value to respective word string
    /// </summary>
    [EnableCors(origins: "*",headers:"*", methods:"*")]
    [RoutePrefix("api/NumberConverter")]
    public class NumberTextConverterController : ApiController
    {
        /// <summary>
        /// This contoller get method converts a currency number to respective word string
        /// For Example:
        /// Input: 145.26
        /// Output: One hundred forty five dollars and twenty six cents
        /// </summary>
        /// <param name="numericValue">dollar numeric value as a string</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>word representation of numeric value</returns>
        // GET api/values
        [HttpGet]
        [Route("GetCurrencyWordConversion")]
        public HttpResponseMessage Get(double numericValue)
        {
            string wordValue = string.Empty;
            HttpResponseMessage responseMessage = null;
            try
            {

                if (double.IsNaN(numericValue))
                {
                    wordValue = "Currency value is empty or invalid.";
                    throw new ArgumentException(wordValue, nameof(numericValue));
                }

                if (numericValue == 0)
                {
                    wordValue = CurrenctConstants.zeroString + " " + CurrenctConstants.dollarString;
                    return responseMessage = GenerateReturnResponce(wordValue, true);
                }

                wordValue = CurrencyNumbersToWordHelper.ConvertToWords(numericValue.ToString("N")).ToUpper();
                responseMessage = GenerateReturnResponce(wordValue.Trim(), true);
            }
            catch (Exception ex)
            {
                responseMessage = GenerateReturnResponce(ex.Message, false);
            }
            
            return responseMessage;
        }

        private HttpResponseMessage GenerateReturnResponce(string message, bool isSuccess)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage()
            {
                Content = new StringContent(message),
                StatusCode = isSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest
            };

            return returnMessage;
        }
    }
}
