using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;
using Zoe.MsSample.Infrastructure.Data.Context;

namespace Zoe.MsSample.Infrastructure.Data.Repositories.CustomerAggregate
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MsSampleDbContext context)
            : base(context)
        { }

        public async Task<Customer> GetByEmailAddressAsync(string emailAddress)
        {
            return await base.DbSet
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Email.Address == emailAddress);
        }
    }
}
