using Store.Core.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.Contract
{
    public interface IUserService
    {
        Task<UserDtos> LoginAsync(LoginDto loginDto);
        Task<UserDtos> RegisterAsync(RegisterDtos registerDtos);
        Task<bool> CheckEmailExistAsync(string email);
    }
}
