using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Admissionstatus
    {
        Select,
        Admitted,
        Cancelled

    }
    public class AdmissionDetails
    {
        static public int IdGenerator3=1001;
        public string AdmissionId { get;  }
        
        public string StudentdIdAdmission { get; set; }
        public string DepartmentIdAdmission { get; set; }
        
        public DateTime AdmissionDate { get; set; }
        public Admissionstatus Status { get; set; }
        
        public AdmissionDetails(string studentdIdAdmission,string departmentIdAdmission,DateTime admissionDate, Admissionstatus status )
        {
            AdmissionId="AID"+IdGenerator3++;
            StudentdIdAdmission=studentdIdAdmission;
            DepartmentIdAdmission=departmentIdAdmission;
            AdmissionDate=admissionDate;
            Status=status;
        }
        
        
        
        
    }
}