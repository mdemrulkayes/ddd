using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Employee: AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Int64 DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
