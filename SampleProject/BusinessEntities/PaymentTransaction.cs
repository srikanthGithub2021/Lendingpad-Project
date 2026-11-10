using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class PaymentTransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SessionId { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal ProvidedAmount { get; set; }
        public decimal ChangeGiven { get; set; }
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
    }
}
