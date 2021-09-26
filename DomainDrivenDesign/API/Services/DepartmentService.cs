using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common.Exceptions;
using API.DTOS.Departments;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Interfaces.Department;
using Domain.Interfaces.Employee;

namespace API.Services
{
    public class DepartmentService: BaseService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository, IMapper mapper, IEmployeeRepository employeeRepository): base(unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<DepartmentResponse> CreateDepartment(AddDepartmentRequest request)
        {
            var data = await _departmentRepository.AddAsync(_mapper.Map<AddDepartmentRequest, Department>(request));
            var result = await UnitOfWork.SaveChangesAsync();

            return _mapper.Map<Department, DepartmentResponse>(data);
        }

        public async Task<List<DepartmentResponse>> GetAllDepartments()
        {
            var data = (await _departmentRepository.GetAllAsync()).ToList();
            var result = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResponse>>(data);
            return result.ToList();
        }

        public async Task<DepartmentResponse> GetDepartment(Int64 id)
        {
            var data = (await _departmentRepository.GetAsync(x => x.Id == id));
            var result = _mapper.Map<Department, DepartmentResponse>(data);
            return result;
        }

        public async Task<DepartmentResponse> UpdateDepartment(Int64 id, AddDepartmentRequest request)
        {
            var data = await _departmentRepository.GetAsync(x => x.Id == id);
            if (data == null)
            {
                throw new NotFoundException("Department not found");
            }
            var mappedResult = _mapper.Map<AddDepartmentRequest, Department>(request, data);
            var result = await _departmentRepository.UpdateAsync(mappedResult);
            await UnitOfWork.SaveChangesAsync();
            return _mapper.Map<Department, DepartmentResponse>(result);
        }

        public async Task<int> DeleteDepartment(Int64 id)
        {
            var data = await _departmentRepository.GetAsync(x => x.Id == id);
            if (data == null)
            {
                throw new NotFoundException("Department not found");
            }

            await _departmentRepository.DeleteAsync(data);
            await UnitOfWork.SaveChangesAsync();
            return 1;
        }
    }
}
