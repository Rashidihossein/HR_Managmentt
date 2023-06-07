﻿using FluentValidation;
using HR_Managment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator (_leaveTypeRepository));   
        }
    }
}
