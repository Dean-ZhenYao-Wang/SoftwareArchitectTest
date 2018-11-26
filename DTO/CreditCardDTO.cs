using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreditCardDTO:BaseDTO
    {
        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }
    }

    public class ValidationCreditCardDTO
    {
        public string CardType { get; set; }

        public string ValidationResult { get; set; }
    }
}
