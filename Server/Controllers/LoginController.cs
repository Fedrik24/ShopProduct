using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ShopProduct.Server.Handler.CommandQuery;
using ShopProduct.Server.Handler.Service;
using ShopProduct.Shared;


namespace ShopProduct.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromHeader(Name = "username")] string username,
            [FromHeader(Name = "password")] string password)
        {
            var query = new UserLoginQuery(username, password);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken([FromHeader(Name = "userId")]int userId)
        {
            var query = new GetTokenQuery(userId);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin([FromHeader(Name = "userid")] int userId, [FromHeader(Name = "token")] string token)
        {
            var query = new UserLoginCommandQuery(userId, token);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> UserRegister([FromBody] RegisterData registerData)
        {
            var query = new RegisterUserCommandQuery(registerData);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
