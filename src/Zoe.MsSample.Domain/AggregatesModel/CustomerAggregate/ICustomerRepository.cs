using System.Threading.Tasks;
using Zoe.Data.Repositories;

namespace Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmailAddressAsync(string emailAddress);
    }
}
