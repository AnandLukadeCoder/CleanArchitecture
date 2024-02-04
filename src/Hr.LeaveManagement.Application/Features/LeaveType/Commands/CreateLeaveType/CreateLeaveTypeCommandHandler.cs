﻿using AutoMapper;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeCreate = _mapper.Map<Domain.LeaveType>(request);            
            leaveTypeCreate.DateCreated = DateTime.UtcNow;
            await _leaveTypeRepository.CreateAsync(leaveTypeCreate);            
            return leaveTypeCreate.Id;
        }
    }
}
