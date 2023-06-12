using AutoMapper;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.DTOs.LeaveType.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //var validator = new UpdateLeaveTypeValidator();
            #region validator
            var validator = new UpdateLeaveTypeValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            #endregion
            var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDTO.Id);
            _mapper.Map(request.LeaveTypeDTO, leaveType);
            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value;
        }

    }
}
