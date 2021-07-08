using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        public IActionResult Authenticate(string username, string password)
        {
            if (_tokenManager.Authenticate())
            {
                // We will return a dynamic object.
                return Ok(new
                {
                    Token = _tokenManager.CreateToken()
                });
            }
            else
            {
                //ModelState.AddModelError("Unauthorized", "You are not authorized.");
                //return new Unauthorized(ModelState);

                return new UnauthorizedResult();
            }
        }
    }
}