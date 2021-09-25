using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IBaseRepository<T> Repository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>(_dbContext);
        }
    }
}
