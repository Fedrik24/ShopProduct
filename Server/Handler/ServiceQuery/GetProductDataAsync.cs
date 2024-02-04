using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;
using ShopProduct.Shared;
using System.Data;

namespace ShopProduct.Server.Handler.Service
{
    public record GetProductDataAsyncQuery : IRequest<IActionResult>;

    public class GetProductDataAsync : IRequestHandler<GetProductDataAsyncQuery, IActionResult>
    {
        private IUserService userService;


        public GetProductDataAsync(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Handle(GetProductDataAsyncQuery request, CancellationToken cancellationToken)
        {
            UserIdLogin result = await userService.GetUser();
            return new OkObjectResult(result);
        }
    }
}
