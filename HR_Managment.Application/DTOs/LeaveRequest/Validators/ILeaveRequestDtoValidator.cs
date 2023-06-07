using FluentValidation;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;


            RuleFor(p => p.StartDate).LessThan(p => p.EndDate)
               .WithMessage("تاریخ شروع نمی تواند کمتر از تاریخ پایان باشد");

            RuleFor(p => p.EndDate).GreaterThan(p => p.StartDate)
               .WithMessage("تاریخ پایان نمی تواند کمتر از تاریخ شروع باشد");



            RuleFor(p => p.LeaveTypeId)
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var leaveTypeExist = await leaveTypeRepository.Exist(id);
                        return !leaveTypeExist;
                    })
                    .WithMessage("وجود ندارد");
        }
    }
}
