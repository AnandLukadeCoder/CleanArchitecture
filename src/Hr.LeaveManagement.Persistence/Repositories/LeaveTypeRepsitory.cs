using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Hr.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepsitory : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepsitory(HrDatabaseContext context) : base(context)
        {
        }

        public Task<bool> IsLeaveTypeUnique(string name)
        {
            return _context.LeaveTypes.AnyAsync(q=>q.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
