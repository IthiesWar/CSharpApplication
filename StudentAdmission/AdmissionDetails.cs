using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum AdmissionStatus
    {
        select,
        admitted,
        cancelled
    }
    public class AdmissionDetails
    {
        private static int s_admissionID=1001;
        public string AdmissionID { get;  }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus{ get; set; }
        
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            AdmissionID="AID"+s_admissionID++;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }
        
        
        
        
        
        
        
        
        
    }
} 