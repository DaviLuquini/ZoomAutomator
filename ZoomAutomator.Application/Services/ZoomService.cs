using ZoomAutomator.Application.DTOs;
using ZoomAutomator.Application.Interfaces;


namespace ZoomAutomator.Application.Services
{
    public class ZoomService : IZoomService
    {
        private readonly IZoomAuthService _authService;

        public ZoomService(IZoomAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CreateMeetingResponse> CreateInstantMeetingAsync(CreateMeetingRequest request)
        {
            var client = _authService.GetClient();
            var meetings = client.Meetings;

            var meeting = await meetings.CreateInstantMeetingAsync(
                userId: request.HostEmail,
                topic: request.Topic,
                agenda: string.Empty
            );

            return new CreateMeetingResponse {
                JoinUrl = meeting.JoinUrl,
                StartUrl = meeting.StartUrl,
                MeetingId = meeting.Id.ToString()
            };
        }
    }
}
