namespace ZoomAutomator.Application.Entities;

public class ZoomAuthConfig
{
    public string ClientId { get; }
    public string ClientSecret { get; }
    public string AccountId { get; }

    public ZoomAuthConfig(string clientId, string clientSecret, string accountId)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
        AccountId = accountId;
    }
}
