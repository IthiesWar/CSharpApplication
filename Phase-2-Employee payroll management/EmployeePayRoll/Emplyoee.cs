using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public enum Location
    {
        chennai,

        bangalore,
        kolkatta
    }
    public enum Gender
    {
        male,

        female,
        transgender
    }
    public class Emplyoee
    {
       static public int EmpNumber=1000;
        public string EmployeeId { get; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public Location Location { get; set; }
        public string TeamName { get; set; }
        
        
        public DateTime DOJ { get; set; }

        public int WorkingDays { get; set; }
        public int Leave { get; set; }
        public Gender Gender { get; set; }
        
        public Emplyoee(string employeeName,string role,Location location,string teamName,DateTime doj,
        int workingDays,int leave,Gender gender)
        {
             EmployeeId="SF"+EmpNumber++;
            EmployeeName=employeeName;
            Role=role;
             Location=location;
            TeamName=teamName;
             DOJ=doj;
            WorkingDays=workingDays;
            Leave=leave;
             Gender=gender;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}