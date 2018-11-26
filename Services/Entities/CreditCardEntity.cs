﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class CreditCardEntity:BaseEntity
    {
       public string CardNumber { get; set; }

       public string CardType { get; set; }

       public DateTime ExpiryDate { get; set; }
    }
}
