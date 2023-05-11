using AspCoreCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.PaymentServ
{
    public interface IPaymentService
    {
        Task<CustomBasket> AddOrUpdatePaymentIntent(string basketId);
    }
}
