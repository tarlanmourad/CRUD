using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developedCRUD.Referance
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public Employee() { }

        public Employee(int employeeId, string firstName, string lastName, string address)
        {
            this.EmployeeID = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }
    }
}
