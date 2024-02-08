using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;

namespace ShopProduct.Server.Handler.Service
{
    public record GetTokenQuery(int userId) : IRequest<IActionResult>;

    public class GetToken : IRequestHandler<GetTokenQuery, IActionResult>
    {
        public IUserService userService;

        public GetToken(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            return new OkObjectResult(await userService.GetUserToken(request.userId));
        }
    }
}
