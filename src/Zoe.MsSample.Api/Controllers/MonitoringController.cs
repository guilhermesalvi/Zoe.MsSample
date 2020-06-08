using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Zoe.ApplicationMessage.Managers;
using Zoe.Domain.Bus;
using Zoe.Domain.Notifications;

namespace Zoe.MsSample.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/monitoring")]
    public class MonitoringController : ApiController
    {
        private readonly IConfiguration _configuration;

        public MonitoringController(IConfiguration configuration,
                                    IMediatorHandler mediator,
                                    INotificationHandler<DomainNotification> notifications,
                                    IApplicationMessageManager appMessageManager)
            : base(mediator, notifications, appMessageManager)
        {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return base.Response(new
            {
                Message = $"Api '{this._configuration.GetValue<string>("Microservice")}' is up!",
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
