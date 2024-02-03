using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShopProduct.Server.Handler.Service
{
    public record GetProductDataAsyncQuery : IRequest<IActionResult>;

    public class GetProductDataAsync : IRequestHandler<GetProductDataAsyncQuery, IActionResult>
    {
        public async Task<IActionResult> Handle(GetProductDataAsyncQuery request, CancellationToken cancellationToken)
        {
            return new OkObjectResult($"ITEM");
        }
    }
}
