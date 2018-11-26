using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.Services.Entities
{
    public class CreditCardEntity:BaseEntity
    {
       public string CardNumber { get; set; }

       public string CardType { get; set; }

       public string ExpiryDate { get; set; }
    }
}
