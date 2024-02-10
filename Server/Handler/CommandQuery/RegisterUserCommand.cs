using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;
using ShopProduct.Shared;

namespace ShopProduct.Server.Handler.CommandQuery
{
    public record RegisterUserCommandQuery(RegisterData registerData) : IRequest<IActionResult>;

    public class RegisterUserCommand : IRequestHandler<RegisterUserCommandQuery, IActionResult>
    {
        private IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Handle(RegisterUserCommandQuery request, CancellationToken cancellationToken)
        {
            ResponseCode response = new ResponseCode();
            var result = await userService.Register(request.registerData);
            if (!result)
            {
                response.Message = "Failed to Register User";
                response.Response = 500;
            }
            response.Message = null;
            response.Response = 200;
            return new OkObjectResult(response);
        }
    }
}
