using HR_Managment.Domain.Common;
using HR_Managment.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDTO : BaseDTO
    {
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Aproved { get; set; }


    }
}
