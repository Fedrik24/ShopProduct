using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;
using ShopProduct.Shared;
using System.Data;

namespace ShopProduct.Server.Handler.Service
{
    public record UserLoginQuery(int userId, string password) : IRequest<IActionResult>;

    public class UserLogin : IRequestHandler<UserLoginQuery, IActionResult>
    {
        private IUserService userService;


        public UserLogin(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            // Check is user exist or not
            var userInfo = userService.GetUserInfo(request.userId, request.password);
            if(userInfo == null)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(null);
        }
    }
}
