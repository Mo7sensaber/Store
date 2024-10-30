using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Dtos.Auth;
using Store.Core.Entities.Identity;
using Store.Core.Services.Contract;
using Store.Error;
using Store.Extention;
using Store.Service.Services.Tokens;
using System.Security.Claims;

namespace Store.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService,UserManager<AppUser> userManager,ITokenService tokenService,IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDtos>> Login(LoginDto loginDto)
        {
            var user=await _userService.LoginAsync(loginDto);
            if (user is null) return Unauthorized(new APIErrorResponse(StatusCodes.Status401Unauthorized));
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDtos>> Register(RegisterDtos loginDto)
        {
            var user = await _userService.RegisterAsync(loginDto);
            if (user is null) return BadRequest(new APIErrorResponse(StatusCodes.Status400BadRequest,"Invalid Registration !!"));
            return Ok(user);
        }
        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDtos>> GetCurrentUser(UserDtos loginDto)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail is null) return BadRequest(new APIErrorResponse(StatusCodes.Status400BadRequest));
            var user=await _userManager.FindByEmailAsync(userEmail);
            if (user is null) return BadRequest(new APIErrorResponse(StatusCodes.Status400BadRequest));
            return Ok(new UserDtos
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreateTokenAsync(user, _userManager)

            });
        }
        [HttpGet("Address")]
        [Authorize]
        public async Task<ActionResult<AddressDtos>> GetCurrentUserAddress(AddressDtos loginDto)
        {
            var user = await _userManager.FindByEmailWithAddressAsync(User);
            if (user is null) return BadRequest(new APIErrorResponse(StatusCodes.Status400BadRequest));
            return Ok(_mapper.Map<AddressDtos>(user.Address));
        }
        [HttpPut("address")]
        [Authorize]
        public async Task<ActionResult<AddressDtos>> UpdateUserAddress(AddressDtos address)
        {
            var user = await _userManager.FindByEmailWithAddressAsync(User);

            if (user is null)
                return BadRequest(new APIErrorResponse(StatusCodes.Status400BadRequest));

            // تعيين العنوان الجديد
            user.Address = _mapper.Map<Address>(address);

            // تحديث بيانات المستخدم
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest(new APIErrorResponse(StatusCodes.Status400BadRequest, "Failed to update address"));

            return Ok(_mapper.Map<AddressDtos>(user.Address));
        }
    }
}
