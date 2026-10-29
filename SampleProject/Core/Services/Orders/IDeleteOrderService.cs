using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
   public interface IDeleteOrderService
    {
        void Delete(Order order);

        void DeleteAll(bool confirm=false);
    }
}
