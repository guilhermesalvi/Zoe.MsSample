using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Zoe.ApplicationMessage.Managers;
using Zoe.Domain.Bus;
using Zoe.Domain.Notifications;
using Zoe.MsSample.Application.Services.Abstractions;
using Zoe.MsSample.Application.ViewModels;

namespace Zoe.MsSample.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _appService;

        public CustomerController(ICustomerAppService appService,
                                  IMediatorHandler mediator,
                                  INotificationHandler<DomainNotification> notifications,
                                  IApplicationMessageManager appMessageManager)
            : base(mediator, notifications, appMessageManager)
        {
            this._appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await this._appService.GetByIdAsync(id);

            return base.Response(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerViewModel model)
        {
            var result = await this._appService.RegisterAsync(model);

            return base.Response(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerViewModel model)
        {
            var result = await this._appService.UpdateAsync(model);

            return base.Response(result);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Remove([FromBody] RemoveCustomerViewModel model)
        {
            var result = await this._appService.RemoveAsync(model);

            return base.Response(result);
        }
    }
}
