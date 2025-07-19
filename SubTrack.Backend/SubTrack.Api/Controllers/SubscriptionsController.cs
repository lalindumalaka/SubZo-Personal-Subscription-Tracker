//SubTrack.Backend/SubTrack.Api/Controllers/SubscriptionsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubTrack.Application.DTOs;
using SubTrack.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SubTrack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        public SubscriptionsController(ISubscriptionService service)
        {
            _service = service;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue(ClaimTypes.Name) ?? User.FindFirstValue("sub");

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetSubscriptions()
        {
            var userId = GetUserId();
            var subs = await _service.GetSubscriptionsAsync(userId);
            return Ok(subs);
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> CreateSubscription([FromBody] SubscriptionDto dto)
        {
            var userId = GetUserId();
            var created = await _service.CreateSubscriptionAsync(dto, userId);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(Guid id, [FromBody] SubscriptionDto dto)
        {
            var userId = GetUserId();
            var result = await _service.UpdateSubscriptionAsync(id, dto, userId);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(Guid id)
        {
            var userId = GetUserId();
            var result = await _service.DeleteSubscriptionAsync(id, userId);
            if (!result) return NotFound();
            return NoContent();
        }
    }
} 
