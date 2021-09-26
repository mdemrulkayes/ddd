using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Employee;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
