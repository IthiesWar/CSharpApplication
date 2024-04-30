using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum AdmissionStatus
    {
        Select,
        Admitted,
        Cancelled
    }
    public class AdmissionDetails 
    {
        private static int s_admissionID=1001;
        public string AdmissionId { get;  }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus Status { get; set; }
        
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus status)
        {
            AdmissionId="AID"+s_admissionID++;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            Status=status;
        }
        
        
        
        
        
        
        
        
        
    }
}