using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Employee
{
    public interface IEmployeeRepository: IBaseRepository<Domain.Entities.Employee>
    {
    }
}
