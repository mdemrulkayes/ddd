using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS.Departments;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Department;

namespace API.Services
{
    public class DepartmentService: BaseService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository, IMapper mapper): base(unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<AddDepartmentResponse> CreateDepartment(AddDepartmentRequest request)
        {
            var data = await _departmentRepository.AddAsync(_mapper.Map<AddDepartmentRequest, Department>(request));
            var result = await UnitOfWork.SaveChangesAsync();

            return _mapper.Map<Department, AddDepartmentResponse>(data);
        }
    }
}
