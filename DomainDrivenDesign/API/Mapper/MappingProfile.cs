using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS.Departments;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //DTO to Entity
            CreateMap<AddDepartmentRequest, Department>()
                .ForMember(x => x.Id, otp => otp.Ignore());

            //Entity to DTO
            CreateMap<Department, DepartmentResponse>();
        }
    }
}
