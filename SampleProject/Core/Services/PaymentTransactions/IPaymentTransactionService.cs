using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.PaymentTransactions
{
    public interface  IPaymentTransactionService
    {
         PaymentTransaction Create();
    }
}
