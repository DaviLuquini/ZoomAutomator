namespace ZoomAutomator.Application.DTOs
{
    public class CreateMeetingRequest
    {
        public string Topic { get; set; } = "Reunião Teste";
        public string HostEmail { get; set; } 
        public DateTime StartTime { get; set; } = DateTime.UtcNow.AddMinutes(5);
    }
}
