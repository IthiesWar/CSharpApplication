using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProps
{
    public partial class EmployeeDetails
    {
        public void Update(string employeeID,string name,DateTime dob,long mobile)
        {
            EmployeeID=employeeID;
            Name=name;
            DOB=dob;
            Mobile=mobile;
        }  
        public void Display()
        {
            Console.WriteLine($"Employee ID{EmployeeID}");
            Console.WriteLine("$Name {Name}");
            Console.WriteLine($"Date of birth {DOB}");
            Console.WriteLine($"Mobile {Mobile}");
        }
    }
}