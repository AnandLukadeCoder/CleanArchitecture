using AutoMapper;
using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Hr.LeaveManagement.Domain;

namespace Hr.LeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile:Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDetailsDto, LeaveType>().ReverseMap();
        }
    }
}
