using AspCoreCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface IBasketRepository
    {
        Task<CustomBasket> GetBasketAsync(string? basketid);
        Task<string> CheckId(string basketid);

        Task<CustomBasket> UpdateBasketAsyc(CustomBasket basket);
        Task<bool> DeleteBasketAsyc(string basketid);
    }
}
