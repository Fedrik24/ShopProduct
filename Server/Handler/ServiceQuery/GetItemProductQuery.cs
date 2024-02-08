using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;
using System.Reflection.Metadata.Ecma335;

namespace ShopProduct.Server.Handler.ServiceQuery
{
    public record GetItemProductQueryAsync : IRequest<IActionResult>;

    public class GetItemProductQuery : IRequestHandler<GetItemProductQueryAsync,IActionResult>
    {
        public IProductService productService;

        public GetItemProductQuery(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Handle(GetItemProductQueryAsync request, CancellationToken cancellationToken)
        {
            var result = await productService.ProductItems();
            return new OkObjectResult(result);
        }
    }
}
