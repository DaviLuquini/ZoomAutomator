using Microsoft.AspNetCore.Mvc;
using ZoomAutomator.Application.DTOs;
using ZoomAutomator.Application.Interfaces;


namespace ZoomAutomator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomController : ControllerBase
    {
        private readonly IZoomService _zoomService;

        public ZoomController(IZoomService zoomService)
        {
            _zoomService = zoomService;
        }

        [HttpPost("create-meeting")]
        public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingRequest request)
        {
            var result = await _zoomService.CreateInstantMeetingAsync(request);
            return Ok(result);
        }
    }
}
