using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Core.Services.VendingMachine;
using Data.Repositories;
namespace Core.Services.VendingMachine
{
    public class VendingMachineService : IVendingMachineService
    {
        private readonly InMemoryVendingStore _store;
        private readonly HttpClient _httpClient; // Stub hook for external payment systems

        public VendingMachineService(InMemoryVendingStore store, HttpClient httpClient)
        {
            _store = store;
            _httpClient = httpClient;
        }

        public void InsertCash(decimal amount)
        {
            if (!_store.Machine.IsActive) return;
            _store.CurrentInsertedCash += amount;
        }

        public async Task<PaymentTransaction> OrderProductAsync(string slotCode, PaymentMethod method)
        {
            var transaction = new PaymentTransaction
            {
                SessionId = _store.CurrentSessionId,
                Method = method
            };

            if (!_store.Machine.IsActive) return FailTx(transaction, "System is Offline.");
            if (!_store.Slots.TryGetValue(slotCode, out var product) || !product.IsActive) return FailTx(transaction, "Invalid slot configuration.");
            if (product.StockQuantity <= 0) return FailTx(transaction, "Out of stock.");

            transaction.TargetAmount = product?.Price ?? 0.00m;

            if (method == PaymentMethod.cash)
            {
                transaction.ProvidedAmount = _store.CurrentInsertedCash;
                if (transaction.ProvidedAmount < transaction.TargetAmount)
                {
                    return FailTx(transaction, $"Insufficient cash balance.");
                }
                transaction.ChangeGiven = transaction.ProvidedAmount - transaction.TargetAmount;
            }
            else
            {
                // Mocking third-party API transaction network confirmation request
                transaction.ProvidedAmount = transaction.TargetAmount;
                transaction.ChangeGiven = 0;
            }


            product.SetStockQuantity(product.StockQuantity - 1);
            transaction.IsSuccess = true;
            transaction.StatusMessage = $"Successfully vended {product.ProductName}. Change: {transaction.ChangeGiven:C}";

            _store.Machine.Balance += transaction.TargetAmount;
            _store.TransactionTable.Add(transaction);
            _store.ResetSession();

            return await Task.FromResult(transaction);
        }

        public bool AuthenticateStaff(VendingMachineUser staffMember)
        {
            if (staffMember != null && staffMember.IsActive && staffMember.UserType != UserTypes.Customer)
            {
                _store.CurrentUser = staffMember;
                return true;
            }
            return false;
        }

        public List<PaymentTransaction> GetTransactionLogTable() =>
            _store.CurrentUser.UserType == UserTypes.Admin ? _store.TransactionTable : new List<PaymentTransaction>();

        public decimal GetMachineTotalSalesSummary() =>
            _store.CurrentUser.UserType == UserTypes.Admin ? _store.TransactionTable.Where(t => t.IsSuccess).Sum(t => t.TargetAmount) : 0;


        public void ClearMachineSalesTable()
        {
            if (_store.CurrentUser.UserType == UserTypes.Admin)
            {
                _store.TransactionTable.Clear();
                _store.Machine.Balance = 0;
            }
        }

        public bool RestockSlot(string slotCode, Product productDetails, int quantity)
        {
            if (_store.CurrentUser.UserType == UserTypes.Customer) return false;

            if (_store.Slots.TryGetValue(slotCode, out var product))
            {

                product.SetIsActive(productDetails.IsActive);
                product.SetStockQuantity(product.StockQuantity + 1);
            }
            else
            {
                productDetails.SetVendingSlot(slotCode);
                productDetails.SetStockQuantity( quantity);
                _store.Slots[slotCode] = productDetails;
            }
            _store.Machine.StockDate = DateTime.UtcNow;
            return true;
        }

        private PaymentTransaction FailTx(PaymentTransaction tx, string cause)
        {
            tx.IsSuccess = false;
            tx.StatusMessage = cause;
            _store.TransactionTable.Add(tx);
            return tx;
        }

       
    }
}

