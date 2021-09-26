using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Interfaces.Department
{
    public interface IDepartmentRepository: IBaseRepository<Entities.Department>
    {
        Task<bool> IsDepartmentNameUnique(string name);
    }
}
