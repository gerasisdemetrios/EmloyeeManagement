using EM.Api.Models;

namespace EM.Api.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EMContext context) : base(context)
        {
        }
    }
}
