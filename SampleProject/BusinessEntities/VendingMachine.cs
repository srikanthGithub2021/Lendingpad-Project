using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class VendingMachine
    {
        public Guid VendingMachineId { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; }
        public decimal Balance { get; set; } // Current physical/cash float inside machine
        public DateTime StockDate { get; set; }
    }
}
