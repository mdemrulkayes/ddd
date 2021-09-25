using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Persistence.Department;
using Microsoft.EntityFrameworkCore;

namespace API.DTOS.Departments
{
    public class AddDepartmentRequestValidator: AbstractValidator<AddDepartmentRequest>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public AddDepartmentRequestValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Department Name can not be empty")
                .NotNull().WithMessage("Department Name can not be empty")
                .MustAsync(DepartmentNameBeUnique).WithMessage("Department Name already Exists");
        }

        private async Task<bool> DepartmentNameBeUnique(string name, CancellationToken cancellationToken)
        {
            return await _departmentRepository.IsDepartmentNameUnique(name);
        }
    }
}
