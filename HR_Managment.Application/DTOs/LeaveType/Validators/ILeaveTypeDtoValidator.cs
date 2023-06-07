using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator: AbstractValidator<ILeaveTypeDTO>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("نام نمی تواند خالی باشد")
                .NotNull()
                .MaximumLength(50).WithMessage("طول نمی تواند بیشتر از 50 کاراکتر باشد");

            RuleFor(p => p.DefaultDay)
                .NotEmpty().WithMessage("روز نمی تواند خالی باشد")
                .GreaterThan(0).WithMessage("روز باید بزرگتر از 0 باشد ")
                .LessThan(100).WithMessage("روز نمی تواند بیشتر از 100 باشد");
        }
    }
}
