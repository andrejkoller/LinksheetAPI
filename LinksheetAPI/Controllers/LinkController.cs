﻿using LinksheetAPI.Services;
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
    }
}
