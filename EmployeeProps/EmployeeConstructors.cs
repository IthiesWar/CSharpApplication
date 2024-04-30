using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProps
{
    public partial class EmployeeDetails
    {
        public EmployeeDetails(string employeeID,string name,DateTime dob,long mobile)
        {
            EmployeeID=employeeID;
            Name=name;
            DOB=dob;
            Mobile=mobile;
        }
    }
}