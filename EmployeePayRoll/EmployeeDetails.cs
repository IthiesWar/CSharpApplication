using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public enum Gender
    {
        male,
        female,
        Trangender
    }
    public enum Branch
    {
        Eymard, Karuna, Madhura
    }
    public enum Team
    {
        Network, Hardware, Developer, Facility
    }
    public class EmployeeDetails
    {
        private static int s_employeeID=3000;
        public string EmployeeID { get;  }
        public string EmployeeName { get; set; }
        public DateTime DOB { get; set; }
        public long MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public Branch Branch{get; set; }
        public Team Team { get; set; }

        public EmployeeDetails(string employeeName,DateTime dob,long mobileNumber,Gender gender,Branch branch,Team team)
        {
            EmployeeID="SF"+s_employeeID;
            EmployeeName=employeeName;
            DOB=dob;
            MobileNumber=mobileNumber;
            Gender=gender;
            Branch=branch;
            Team=team;
        }
    }
}