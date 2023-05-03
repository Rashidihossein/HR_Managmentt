﻿using HR_Managment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Domain.DTOs
{
    public class LeaveAlloactionDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }

        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}