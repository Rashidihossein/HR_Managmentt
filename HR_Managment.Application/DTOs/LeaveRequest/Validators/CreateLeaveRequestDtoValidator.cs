using FluentValidation;
using HR_Managment.Application.DTOs.LeaveType.Validators;
using HR_Managment.Application.Persistence.Contracts;

namespace HR_Managment.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestsDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

           Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
        }
       
    }
}
