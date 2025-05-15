using ZoomAutomator.Application.Entities;
using ZoomAutomator.Application.Interfaces;
using ZoomNet;
using ZoomNet.Models;

namespace ZoomAutomator.Application.Services
{
    public class ZoomAuthService : IZoomAuthService
    {
        private readonly ZoomClient _client;

        private readonly ZoomAuthConfig _config;

        public ZoomAuthService(ZoomAuthConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            var connectionInfo = OAuthConnectionInfo.ForServerToServer(_config.ClientId, _config.ClientSecret, _config.AccountId);
            _client = new ZoomClient(connectionInfo);
        }

        public ZoomClient GetClient()
        {
            return _client;
        }
    }
}
