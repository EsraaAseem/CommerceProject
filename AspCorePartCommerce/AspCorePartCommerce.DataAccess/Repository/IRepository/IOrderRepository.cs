using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<Orders> CratedOrderAsyc(string BuryEmail, Guid DelivaryMethodId, string basketId, Address shippingAddress);
        Task<IReadOnlyList<Orders>> GetOrderForUserAsyc(string BuryEmail);
        Task<Orders> getOrderByIdAsyc(Guid id, string buryEmail);
        // Task<IReadOnlyList<DelivaryMethod>> GetDelivaryMethodAsyc();
        public void save();


    }
}
