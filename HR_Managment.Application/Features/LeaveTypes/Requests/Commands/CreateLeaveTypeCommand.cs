using HR_Managment.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand:IRequest<int>
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}
