using AutoMapper;
using HR_Managment.Application.DTOs.LeaveRequest.Validators;
using HR_Managment.Application.Features.LeaveRequests.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using HR_Managment.Domain;
using MediatR;
using HR_Managment.Application.Exceptions;

namespace HR_Managment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestsCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (validationResult.IsValid == false) { 
                throw new ValidationException(validationResult);
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            return leaveRequest.Id;
        }
    }
}
