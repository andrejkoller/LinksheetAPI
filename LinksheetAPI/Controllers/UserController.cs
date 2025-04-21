using LinksheetAPI.Models;
using LinksheetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinksheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private new readonly UserService _userService;

        public UserController(UserService userService) : base(userService)
        {
            _userService = userService;
        }

        [HttpGet("current")]
        public IActionResult GetCurrentUser()
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            var user = _userService.GetUserById(CurrentUser.Id);

            return Ok(user);
        }

        [HttpPut("put/{id}")]
        public IActionResult Update(User user)
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            _userService.UpdateUser(CurrentUser.Id, user);

            return NoContent();
        }
    }
}
