using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        static public int IdGenerator2=101;
        public string DepartmentId { get; }
        
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            DepartmentId="DID"+IdGenerator2++;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
        }
    }
}