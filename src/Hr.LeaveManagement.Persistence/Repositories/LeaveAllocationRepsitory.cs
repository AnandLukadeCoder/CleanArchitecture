using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Hr.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepsitory : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepsitory(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocation(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(
                q=>q.EmployeeId==userId 
                && q.Period==period 
                && q.LeaveTypeId ==leaveTypeId);
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x=>x.Id==id);
            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Where(x=>x.EmployeeId==userId)
                .Include(x => x.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
           return await _context.LeaveAllocations
                .FirstOrDefaultAsync(x=>x.EmployeeId== userId 
                && x.LeaveTypeId==leaveTypeId);
        }
    }
}
