using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IBaseRepository<T> Repository<T>() where T : BaseEntity;
    }
}
