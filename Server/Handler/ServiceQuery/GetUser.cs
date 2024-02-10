using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;

namespace ShopProduct.Server.Handler.Service
{
    public record GetUserQuery(int userId) : IRequest<IActionResult>;

    public class GetUser : IRequestHandler<GetUserQuery, IActionResult>
    {
        public IUserService userService;

        public GetUser(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return new OkObjectResult(await userService.GetUserByUserId(request.userId));
        }
    }
}
