using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;

namespace Domain.Interfaces.Employee
{
    public interface IEmployeeRepository: IBaseRepository<Entities.Employee>
    {
    }
}
