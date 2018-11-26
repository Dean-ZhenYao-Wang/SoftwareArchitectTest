using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.IServices
{
    public interface ICreditCardService: IServiceSupport
    {
        bool ValidationCreditCard(string cardNumber, DateTime expiryDate);
    }
}
