﻿using AutoMapper;
using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Domain;
using HR_Managment.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           CreateMap<LeaveRequest, LeaveRequestDTO >().ReverseMap();    
           CreateMap<LeaveRequest, LeaveRequestListDTO >().ReverseMap();    
           CreateMap<LeaveAllocation, LeaveAlloactionDTO >().ReverseMap();    
           CreateMap<LeaveType, LeaveTypeDTO >().ReverseMap();    
        }
    }
}
