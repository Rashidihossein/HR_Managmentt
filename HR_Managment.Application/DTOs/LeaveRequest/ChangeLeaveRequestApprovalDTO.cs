using HR_Managment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDTO : BaseDTO
    {
        public bool? Approved { get; set; }

    }
}
