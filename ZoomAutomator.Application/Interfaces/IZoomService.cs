using ZoomAutomator.Application.DTOs;

namespace ZoomAutomator.Application.Interfaces
{
    public interface IZoomService
    {
        Task<CreateMeetingResponse> CreateInstantMeetingAsync(CreateMeetingRequest request);
    }
}
