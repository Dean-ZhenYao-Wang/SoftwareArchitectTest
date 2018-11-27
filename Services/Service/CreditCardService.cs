using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZYW.DTO;
using ZYW.IServices;

namespace ZYW.Services.Service
{
    public class CreditCardService : ICreditCardService
    {
        //1.result(valid,invalid,does not exist)
        //2.card type(visa,master,amex,jcb or unknown)

        /// <summary>
        /// Determine whether the input information is valid
        /// </summary>
        /// <param name="creditCardDTO">Credit card information</param>
        /// <param name="type">Credit card type</param>
        /// <returns>true:valid false:invalid</returns>
        private bool Validation(CreditCardDTO creditCardDTO, ref string type)
        {
            //6.only amex card number has 15 digits,the rest of card types have 16 digits.
            if (creditCardDTO.CardNumber.Length == 16)
            {
                int year = Convert.ToInt32(creditCardDTO.ExpiryDate.Substring(2, 4));
                //1.visa is a card number starting wiht 4,
                //7.a valid visa card is the card number where expiry year is a leap year.
                if (creditCardDTO.CardNumber.Substring(0, 1).Equals("4") && DateTime.IsLeapYear(year))
                {
                    type = "visa";
                    return true;
                }
                //2.mastercard is a card number starting with 5.
                //8.a valid mastercard card is the card number where expiry year is prime number.
                else if (creditCardDTO.CardNumber.Substring(0, 1).Equals("5") && IsProbablePrime(Convert.ToInt32(creditCardDTO.ExpiryDate)))
                {
                    type = "master";
                    return true;
                }
                //4.jcb is a card number starting wiht 3528-2589.
                //9.every jcb card is valid.
                else if (creditCardDTO.CardNumber.StartsWith("35282589"))
                {
                    type = "jcb";
                    return true;
                }
                //5.the card starting with any other number is "unknown".
                else
                {
                    type = "unknown";
                    return true;
                }
            }
            //3.amex is a card number starting with 34,37.
            //6.only amex card number has 15 digits,the rest of card types have 16 digits.
            else if (creditCardDTO.CardNumber.Length == 15)
            {
                //3.amex is a card number starting with 34,37.
                //6.only amex card number has 15 digits,the rest of card types have 16 digits.
                if (creditCardDTO.CardNumber.StartsWith("34") ||
                creditCardDTO.CardNumber.StartsWith("37"))
                {

                    type = "amex";
                    return true;
                }
                //5.the card starting with any other number is "unknown".
                else
                {
                    type = "unknown";
                    return true;
                }
            }
            //11.the rest case is "invalid" card.
            else
            {
                return false;
            }
        }

        private bool IsProbablePrime(int source)
        {
            bool b = true;
            if (source == 1 || source == 2)
                b = true;
            else
            {
                int sqr = Convert.ToInt32(Math.Sqrt(source));
                for (int i = sqr; i > 2; i--)
                {
                    if (source % i == 0)
                    {
                        b = false;
                    }
                }
            }
            return b;
        }

        public ValidationCreditCardDTO ValidationCreditCard(CreditCardDTO creditCardDTO)
        {
            string type = "";
            ValidationCreditCardDTO validationCreditCardDTO = new ValidationCreditCardDTO();

            bool vlidation = Validation(creditCardDTO, ref type);
            validationCreditCardDTO.CardType = type;
            if (vlidation)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    SqlParameter cardnumber = new SqlParameter("@cardnumber", creditCardDTO.CardNumber);
                    SqlParameter expiryDate = new SqlParameter("@expiryDate", creditCardDTO.ExpiryDate);
                    SqlParameter result = new SqlParameter("@ValidationResult", SqlDbType.NVarChar,20);
                    result.Direction = ParameterDirection.Output;
                    db.Database.SqlQuery<string>("exec ValidationCreditCard @cardnumber,@expiryDate,@ValidationResult out", cardnumber, expiryDate, result).FirstOrDefault();

                    if (string.IsNullOrEmpty(result.Value.ToString()))
                    {
                        validationCreditCardDTO.ValidationResult = "valid";
                    }
                    else
                    {
                        validationCreditCardDTO.ValidationResult = result.Value.ToString();
                    }
                }
            }
            else
            {
                validationCreditCardDTO.ValidationResult = "invalid";
            }
            return validationCreditCardDTO;
        }
    }
}
