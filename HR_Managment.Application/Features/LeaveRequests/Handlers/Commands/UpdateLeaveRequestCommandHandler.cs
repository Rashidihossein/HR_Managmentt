using AutoMapper;
using HR_Managment.Application.DTOs.LeaveRequest.Validators;
using HR_Managment.Application.Features.LeaveRequests.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using ValidationException = HR_Managment.Application.Exceptions.ValidationException;

namespace HR_Managment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository
            ,IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if(request.LeaveRequestDTO != null) { 
            _mapper.Map(request.LeaveRequestDTO, leaveRequest);
            await _leaveRequestRepository.Update(leaveRequest);
            }
            else if(request.ChangeLeaveRequestApprovalDTO != null) {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDTO.Approved);
            }
            return Unit.Value;
        }
    }
}
