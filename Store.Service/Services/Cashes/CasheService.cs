using StackExchange.Redis;
using Store.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Service.Services.Cashes
{
    public class CasheService : ICasheService
    {
        private readonly IDatabase database;

        public CasheService(IConnectionMultiplexer redis)
        {
            database = redis.GetDatabase();
        }
        public async Task<string> GetCasheAsync(string key)
        {
            var casheResponse= await database.StringGetAsync(key);
            if (casheResponse.IsNullOrEmpty) return null;
            else
                return casheResponse.ToString();
        }

        public async Task SetCasheAsync(string key, object response, TimeSpan expireTime)
        {
            if (response is null) return;
            var option = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            await database.StringSetAsync(key,JsonSerializer.Serialize(response,option),expireTime);
        }
    }
}
