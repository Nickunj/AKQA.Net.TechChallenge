using System;
using AKQA.Services.Constants;
namespace AKQA.Services.Helper
{
    /// <summary>
    /// Helper class to convert currency number to word representation
    /// </summary>
    public static class CurrencyNumbersToWordHelper
    {

        /// <summary>
        /// Helper function to convert currency number to word representation
        /// </summary>
        /// <param name="number">Currency number</param>
        /// <returns>Word representation of currency numbers</returns>
        public static string ConvertToWords(string number)
        {
            string value = string.Empty;
            string currencyValue = number;
            string dollars = "0";
            string cents = string.Empty;
            bool isMinusNumber = false;

            try
            {
                if (currencyValue != null)
                {
                    int decimalPlace = currencyValue.IndexOf(".", StringComparison.Ordinal);
                    if (decimalPlace > 0)
                    {
                        dollars = currencyValue.Substring(0, decimalPlace);
                        cents = currencyValue.Substring(decimalPlace + 1);
                        if (Convert.ToInt32(cents) > 0)
                        {
                            cents = ConvertWholeNumber(cents);
                        }
                        else
                        {
                            cents = string.Empty;
                        }
                    }

                    if (dollars.Contains("-"))
                    {
                        isMinusNumber = true;
                        dollars = dollars.Substring(1, dollars.Length - 1);
                    }
                    dollars = ConvertWholeNumber(dollars).Trim();
                }

                
                value = string.Format("{0} {1} {2} {3} {4} {5}",
                    GetMinusConstantString(isMinusNumber),
                    dollars,
                    GetDollarsConstantString(dollars),
                    GetDollarsCentsConnectorConstString(dollars, cents),
                    cents,
                    GetCentsConstantString(cents));
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return value.ToUpper().Trim();
        }

        private static string GetMinusConstantString(bool isMinus)
        {
            return isMinus 
                ? CurrenctConstants.minusString 
                : string.Empty;
        }

        private static string GetDollarsConstantString(string dollars)
        {
            return string.IsNullOrEmpty(dollars)
                ? string.Empty
                : CurrenctConstants.dollarString;
        }

        private static string GetDollarsCentsConnectorConstString(string dollars, string cents)
        {
            return string.IsNullOrEmpty(dollars) || string.IsNullOrEmpty(cents)
                ? string.Empty
                : CurrenctConstants.andString;
        }

        private static string GetCentsConstantString(string cents)
        {
            return string.IsNullOrEmpty(cents)
                ? string.Empty
                : CurrenctConstants.centsString;
        }

        private static string ConvertWholeNumber(string number)
        {
            string wordConversion = string.Empty;
            number = number.Trim(',');
            try
            {
                bool isConverted = false; 
                double dblAmt = (Convert.ToDouble(number));
                if (dblAmt > 0 )
                {
                    int totalDigits = dblAmt.ToString().Length;
                    int numberPosition = 0; 
                    string numberAtPlace = ""; 
                    switch (totalDigits)
                    {
                        case 1:
                            wordConversion = GetNumberOnOnesPosition(number);
                            isConverted = true;
                            break;
                        case 2:
                            wordConversion = GetNumberOnTensPosition(number);
                            isConverted = true;
                            break;
                        case 3: 
                            numberPosition = (totalDigits % 3) + 1;
                            numberAtPlace = " hundred ";
                            break;
                        case 4: 
                        case 5:
                        case 6:
                            numberPosition = (totalDigits % 4) + 1;
                            numberAtPlace = " thousand ";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            numberPosition = (totalDigits % 7) + 1;
                            numberAtPlace = " million ";
                            break;
                        case 10: 
                        case 11:
                        case 12:
                            numberPosition = (totalDigits % 10) + 1;
                            numberAtPlace = " billion ";
                            break;
                        case 13: 
                        case 14:
                        case 15:
                            numberPosition = (totalDigits % 13) + 1;
                            numberAtPlace = " trillion ";
                            break;
                        default:
                        {
                            isConverted = true;
                            if (totalDigits <= 15)
                                break;
                            else
                                throw new Exception("Too big number. This function supports a value upto 15 digits.");
                        }
                    }

                    if (!isConverted)
                    {
                        if (number.Substring(0, numberPosition) != "0" && number.Substring(numberPosition) != "0")
                        {
                            try
                            {
                                wordConversion = ConvertWholeNumber(number.Substring(0, numberPosition)) + numberAtPlace +
                                       ConvertWholeNumber(number.Substring(numberPosition));
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                        else
                        {
                            wordConversion = ConvertWholeNumber(number.Substring(0, numberPosition)) +
                                   ConvertWholeNumber(number.Substring(numberPosition));
                        }
                    }

                    if (wordConversion.Trim().Equals(numberAtPlace.Trim())) wordConversion = "";
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return wordConversion.Trim();
        }

        private static string GetNumberOnTensPosition(string number)
        {
            int numberOnTenthPosition = Convert.ToInt32(number.Trim(','));
            string wordConversion = string.Empty;
            switch (numberOnTenthPosition)
            {
                case 10:
                    wordConversion = "ten";
                    break;
                case 11:
                    wordConversion = "eleven";
                    break;
                case 12:
                    wordConversion = "twelve";
                    break;
                case 13:
                    wordConversion = "thirteen";
                    break;
                case 14:
                    wordConversion = "fourteen";
                    break;
                case 15:
                    wordConversion = "fifteen";
                    break;
                case 16:
                    wordConversion = "sixteen";
                    break;
                case 17:
                    wordConversion = "seventeen";
                    break;
                case 18:
                    wordConversion = "eighteen";
                    break;
                case 19:
                    wordConversion = "nineteen";
                    break;
                case 20:
                    wordConversion = "twenty";
                    break;
                case 30:
                    wordConversion = "thirty";
                    break;
                case 40:
                    wordConversion = "fourty";
                    break;
                case 50:
                    wordConversion = "fifty";
                    break;
                case 60:
                    wordConversion = "sixty";
                    break;
                case 70:
                    wordConversion = "seventy";
                    break;
                case 80:
                    wordConversion = "eighty";
                    break;
                case 90:
                    wordConversion = "ninety";
                    break;
                default:
                    if (numberOnTenthPosition > 0)
                    {
                        wordConversion = GetNumberOnTensPosition(number.Substring(0, 1) + "0") + " " + GetNumberOnOnesPosition(number.Substring(1));
                    }
                    break;
            }

            return wordConversion;
        }

        private static string GetNumberOnOnesPosition(string number)
        {
            int numberOnOnesPosition = Convert.ToInt32(number.Trim(','));
            string wordConversion = string.Empty;
            switch (numberOnOnesPosition)
            {

                case 1:
                    wordConversion = "one";
                    break;
                case 2:
                    wordConversion = "two";
                    break;
                case 3:
                    wordConversion = "three";
                    break;
                case 4:
                    wordConversion = "four";
                    break;
                case 5:
                    wordConversion = "five";
                    break;
                case 6:
                    wordConversion = "six";
                    break;
                case 7:
                    wordConversion = "seven";
                    break;
                case 8:
                    wordConversion = "eight";
                    break;
                case 9:
                    wordConversion = "nine";
                    break;
            }

            return wordConversion;
        }
    }
}