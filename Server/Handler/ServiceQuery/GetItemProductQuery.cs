using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ShopProduct.Server.Handler.ServiceQuery
{
    public record GetItemProductQueryAsync : IRequest<IActionResult>;

    public class GetItemProductQuery : IRequestHandler<GetItemProductQueryAsync,IActionResult>
    {
        public async Task<IActionResult> Handle(GetItemProductQueryAsync request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
