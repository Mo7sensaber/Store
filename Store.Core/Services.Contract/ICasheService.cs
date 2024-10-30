using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.Contract
{
    public interface ICasheService
    {
        Task SetCasheAsync(string key, object response, TimeSpan expireTime);
        Task<string> GetCasheAsync(string key);

    }
}
