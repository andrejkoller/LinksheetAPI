using LinksheetAPI.Models;
using LinksheetAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinksheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController : BaseController
    {
        private readonly LinkService _linkService;
        public LinkController(LinkService linkService, UserService userService) : base(userService)
        {
            _linkService = linkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            var links = await _linkService.GetAllLinks();

            return links == null ? NotFound() : Ok(links);
        }

        [HttpGet("currentUser")]
        public async Task<IActionResult> GetCurrentUserLinks()
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            var links = await _linkService.GetLinksByUserId(CurrentUser.Id);
            return links == null ? NotFound() : Ok(links);
        }

        [HttpPost("post")]
        public IActionResult Post([FromBody] Link link)
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            if (link == null)
            {
                return BadRequest("Link cannot be null.");
            }

            link.UserId = CurrentUser.Id;
            _linkService.PostLink(link);

            return CreatedAtAction(nameof(GetAllLinks), new { id = link.Id }, link);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            var isDeleted = await _linkService.DeleteLink(id);

            if (!isDeleted)
            {
                return NotFound($"Link with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpPut("put/{id}")]
        public IActionResult Update(int id, Link link)
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            if (link == null)
            {
                return BadRequest("Link cannot be null");
            }

            _linkService.UpdateLink(id, link);

            return NoContent();
        }

        [HttpPut("put/{id}/toggle")]
        public IActionResult ToggleLinkVisibility(int id, Link link)
        {
            if (CurrentUser == null)
            {
                return Unauthorized();
            }

            if (link == null)
            {
                return BadRequest("Link cannot be null");
            }

            _linkService.UpdateLinkVisibility(id, link);

            return NoContent();
        }
    }
}
