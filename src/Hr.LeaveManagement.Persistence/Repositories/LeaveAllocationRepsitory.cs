using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Persistence.DatabaseContext;

namespace Hr.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepsitory : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepsitory(HrDatabaseContext context) : base(context)
        {
        }
    }
}
