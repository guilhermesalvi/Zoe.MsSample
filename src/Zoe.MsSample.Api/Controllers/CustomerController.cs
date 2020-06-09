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
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiVersion("1")]
    [Produces("application/json")]
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

        /// <summary>
        /// Gets a customer by its identifier.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /0c785e60-bbc8-4372-9c3e-df77e2713d8a
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await this._appService.GetByIdAsync(id);

            return base.Response(result, unsuccessStatusCode: 404);
        }

        /// <summary>
        /// Register a new customer.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     POST /
        ///     {
        ///         "FullName": "The Customer FullName",
        ///         "Alias": "The Customer Alias",
        ///         "Email": "anemail@email.com",
        ///         "BirthDate": "1970-07-06"
        ///     }
        /// 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Register([FromBody] RegisterCustomerViewModel model)
        {
            var result = await this._appService.RegisterAsync(model);

            return base.Response(result, successStatusCode: 201);
        }

        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     PUT /
        ///     {
        ///         "Id": "0c785e60-bbc8-4372-9c3e-df77e2713d8a",
        ///         "FullName": "The Customer FullName",
        ///         "Alias": "The Customer Alias",
        ///         "Email": "anemail@email.com",
        ///         "BirthDate": "1970-07-06"
        ///     }
        /// 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerViewModel model)
        {
            var result = await this._appService.UpdateAsync(model);

            return base.Response(result, successStatusCode: 204);
        }

        /// <summary>
        /// Remove a customer.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     DELETE /
        ///     {
        ///         "Id": "0c785e60-bbc8-4372-9c3e-df77e2713d8a"
        ///     }
        /// 
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> Remove([FromBody] RemoveCustomerViewModel model)
        {
            var result = await this._appService.RemoveAsync(model);

            return base.Response(result);
        }
    }
}
