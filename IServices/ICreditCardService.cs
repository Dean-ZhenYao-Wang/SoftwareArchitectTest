using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYW.DTO;

namespace ZYW.IServices
{
    public interface ICreditCardService: IServiceSupport
    {
        ValidationCreditCardDTO ValidationCreditCard(CreditCardDTO creditCardDTO);
    }
}
