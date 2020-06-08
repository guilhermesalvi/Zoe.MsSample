using System;
using System.Threading.Tasks;
using Zoe.MsSample.Application.ViewModels;

namespace Zoe.MsSample.Application.Services.Abstractions
{
    public interface ICustomerAppService
    {
        Task<string> RegisterAsync(RegisterCustomerViewModel model);
        Task<string> RemoveAsync(RemoveCustomerViewModel model);
        Task<string> UpdateAsync(UpdateCustomerViewModel model);
        Task<CustomerViewModel> GetByIdAsync(Guid id);
    }
}
