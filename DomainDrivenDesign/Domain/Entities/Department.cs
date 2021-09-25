using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Department: AuditableEntity
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
