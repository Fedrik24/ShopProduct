using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;
using ShopProduct.Shared;

namespace ShopProduct.Server.Handler.CommandQuery
{
    public record UserPurchaseItemsCommandQuery(UserPurchase UserPurchase) : IRequest<IActionResult>;

    public class UserPurchaseItemsCommand : IRequestHandler<UserPurchaseItemsCommandQuery, IActionResult>
    {
        public IProductService productService;

        public UserPurchaseItemsCommand(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Handle(UserPurchaseItemsCommandQuery request, CancellationToken cancellationToken)
        {
            ResponseCode response = new ResponseCode();

            var isAfforToBuy = await productService.CalculateCurrency(request.UserPurchase.UserId, request.UserPurchase.ProductType, request.UserPurchase.Price);

            if (!isAfforToBuy)
            {
                response.Message = $"user : {request.UserPurchase.UserId} cannot afford to buy";
                response.Response = 204;
                return new OkObjectResult(response);
            }

            var result = await productService.InsertUserProductHistory(request.UserPurchase);

            if (result)
            {
                response.Response = 200;
                response.Message = "Insert User History Purchase Successfull";
            }
            else
            {
                response.Response = 500;
            }
            return new OkObjectResult(response);
        }
    }
}
