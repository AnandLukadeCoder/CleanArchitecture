using AutoMapper;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //get data from database
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            //autompper mapping
            var result = _mapper.Map<LeaveTypeDetailsDto>(leaveType);
            //return result
            return result;            
        }
    }
}
