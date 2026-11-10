using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class InMemoryVendingStore
    {
        // Concrete instantiations for broad .NET Framework compatibility
        public VendingMachine Machine { get; } = new VendingMachine
        {
            Balance = 0.00m,
            StockDate = DateTime.UtcNow
        };

        public Dictionary<string, Product> Slots { get; } = new Dictionary<string, Product>();
        public List<PaymentTransaction> TransactionTable { get; } = new List<PaymentTransaction>();

        // Active Session Variables
        public VendingMachineUser CurrentUser { get; set; } = new VendingMachineUser
        {
           
            UserType = UserTypes.Customer,
            IsActive = true,
            UserTimeOutInSeconds = 30
        };

        public decimal CurrentInsertedCash { get; set; }
        public Guid CurrentSessionId { get; set; } = Guid.NewGuid();

        public void ResetSession()
        {
            CurrentUser = new VendingMachineUser
            {
                UserType = UserTypes.Customer,
                IsActive = true,
                UserTimeOutInSeconds = 30
            };
            CurrentInsertedCash = 0.00m;
            CurrentSessionId = Guid.NewGuid();
        }
    }
}
