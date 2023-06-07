using FluentValidation;
using HR_Managment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
          this. _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays).GreaterThan(0)
                .WithMessage("{PropertyName} Must Greater Than {ComparisonValue}");

            RuleFor(p => p.Period).GreaterThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("{PropertyName} Must be After {ComparisonValue}");

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
