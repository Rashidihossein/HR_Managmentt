using AutoMapper;
using HR_Managment.Application.DTOs.LeaveAllocation.Validators;
using HR_Managment.Application.DTOs.LeaveRequest.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using HR_Managment.Domain;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Commands
{

    
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository
            , IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDTO);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
