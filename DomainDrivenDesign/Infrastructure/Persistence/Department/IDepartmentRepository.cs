using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Department
{
    public interface IDepartmentRepository: IBaseRepository<Domain.Entities.Department>
    {
        Task<bool> IsDepartmentNameUnique(string name);
    }
}
