using AutoMapper;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using HR_Managment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            var leaveType = await _leaveTypeRepository.Get(request.Id);
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            await _leaveTypeRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
}
