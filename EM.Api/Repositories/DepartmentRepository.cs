using EM.Api.Models;

namespace EM.Api.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EMContext context) : base(context)
        {
        }
    }
}
