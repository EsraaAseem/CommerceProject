using AspCoreCommerce.Model;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using StackExchange.Redis;
using System.Linq.Expressions;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AspCorePartCommerce.DataAccess.Repository
{
    public class BasketRepository : IBasketRepository
    {
       private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsyc(string basketid)
        {
            return await _database.KeyDeleteAsync(basketid);
        }

       
        public async Task<CustomBasket> GetBasketAsync(string? basketid)
        {
              var  data = await _database.StringGetAsync(basketid);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomBasket>(data);
        }
        public async Task<string> CheckId(string basketid)
        {
            var data = await _database.StringGetAsync(basketid);
            return data;
        }
        public async Task<CustomBasket> UpdateBasketAsyc(CustomBasket basket)
        {
            var created=await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
            if (!created) return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}
