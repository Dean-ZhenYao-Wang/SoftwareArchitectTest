﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.DTO
{
    public class CreditCardDTO
    {
        public string CardNumber { get; set; }

        public string ExpiryDate { get; set; }
    }

    public class ValidationCreditCardDTO
    {
        public string CardType { get; set; }

        public string ValidationResult { get; set; }
    }
}
