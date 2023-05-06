using AutoMapper;
using HR_Managment.Application.Features.LeaveTypes.Requests.Queries;
using HR_Managment.Application.Persistence.Contracts;
using HR_Managment.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeList= await _leaveTypeRepository.GetAll();

            return _mapper.Map<List<LeaveTypeDTO>>(leaveTypeList);
        }
    }
}
