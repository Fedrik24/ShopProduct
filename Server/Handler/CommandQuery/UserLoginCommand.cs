using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Services;
using ShopProduct.Shared;

namespace ShopProduct.Server.Handler.CommandQuery
{
    public record UserLoginCommandQuery(int userId, string token) : IRequest<IActionResult>;

    public class UserLoginCommand : IRequestHandler<UserLoginCommandQuery, IActionResult>
    {

        private IUserService userService;

        public UserLoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Handle(UserLoginCommandQuery request, CancellationToken cancellationToken)
        {
            var isUserIdExist = await userService.GetUserId(request.userId);
            if(isUserIdExist <= 0)
            {
                return new NotFoundResult();
            }

            var insertUserIdToken = await userService.InsertUserToken(request.userId, request.token);

            if (insertUserIdToken)
            {
                return new OkObjectResult(new ResponseCode()
                {
                    Message = $"Insert userId : {request.userId} Success",
                    Response = 200
                });
            }
            return new EmptyResult();
        }
    }
}
