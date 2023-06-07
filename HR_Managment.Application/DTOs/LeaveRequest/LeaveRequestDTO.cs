﻿using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Domain;
using HR_Managment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDTO : BaseDTO,ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }

        public LeaveTypeDTO LeaveType { get; set; }

        public DateTime DateRequested { get; set; }

        public string RequestComments { get; set; }

        public DateTime? DateActioned { get; set; }

        public bool? Aproved { get; set; }

        public bool Cancelled { get; set; }
    }
}
