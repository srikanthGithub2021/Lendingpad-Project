using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using System.Threading.Tasks;

namespace Core.Services.VendingMachine
{
   
    public interface IVendingMachineService
    {
        void InsertCash(decimal amount);
        Task<PaymentTransaction> OrderProductAsync(string slotCode, PaymentMethod method);
        bool AuthenticateStaff(VendingMachineUser staffMember);
        List<PaymentTransaction> GetTransactionLogTable();
        decimal GetMachineTotalSalesSummary();
        void ClearMachineSalesTable();
        bool RestockSlot(string slotCode, Product productDetails, int quantity);
    }
}
