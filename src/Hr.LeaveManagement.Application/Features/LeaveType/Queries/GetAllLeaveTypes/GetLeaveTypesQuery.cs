using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQuery:IRequest<LeaveTypeDetailsDto>
    {
        public int Id { get; set; }
    }
}
