using System;
using System.Collections.Generic;

namespace WebApi_First.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int DepartmentId { get; set; }

        public virtual Department? Department { get; set; } = null!;
    }
}
