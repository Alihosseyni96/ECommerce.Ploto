using ECommerce.Ploto.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.Product.ValueObject
{
    public class Money
    {
        public decimal Amount { get;  }
        public string Currency { get;  }

        public Money(decimal amount , string currency)
        {
            if (Amount < 0)
                throw new productAnountException();

            Amount = amount;
            Currency = currency;
        }
    }
}
