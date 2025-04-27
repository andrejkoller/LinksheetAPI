using LinksheetAPI.Models;
using LinksheetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinksheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkSpaceController : BaseController
    {
        private readonly LinkSpaceService _linkSpaceService;

        public LinkSpaceController(LinkSpaceService linkSpaceService, UserService userService) : base(userService)
        {
            _linkSpaceService = linkSpaceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLinkSpaces()
        {
            var linkSpaces = await _linkSpaceService.GetAllLinkSpaces();

            return linkSpaces == null ? NotFound() : Ok(linkSpaces);
        }

        [HttpGet("currentUser")]
        public async Task<IActionResult> GetCurrentUserLinkSpace()
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            var linkSpace = await _linkSpaceService.GetLinkSpaceByUserId(CurrentUser.Id);

            return linkSpace == null ? NotFound() : Ok(linkSpace);
        }

        [HttpPost("post")]
        public IActionResult Post([FromBody] LinkSpace linkSpace)
        {
            if (linkSpace == null)
            {
                return BadRequest("LinkSpace cannot be null.");
            }

            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            linkSpace.UserId = CurrentUser.Id;
            var createdLinkSpace = _linkSpaceService.PostLinkSpace(linkSpace);

            return CreatedAtAction(nameof(GetCurrentUserLinkSpace), new { id = createdLinkSpace.Id }, createdLinkSpace);
        }

        [HttpPut("put/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LinkSpace linkSpace)
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            if (linkSpace == null)
            {
                return BadRequest("Updated LinkSpace cannot be null.");
            }

            try
            {
                var updatedLinkSpace = await _linkSpaceService.UpdateLinkSpace(id, linkSpace);
                return updatedLinkSpace == null ? NotFound() : Ok(updatedLinkSpace);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
