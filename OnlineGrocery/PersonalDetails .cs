using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public enum Gender{
        male,
        female,transegender
    }
    public class PersonalDetails 
    {
        //Properties: Name, FatherName, Gender, Mobile, DOB, MailID
        public string Name { get; set; }
        
        public string FatherName { get; set; }
        
        public Gender Gender { get; set; }
        public long Mobile { get; set; }
        
        public DateTime DOB { get; set; }
        
        public string MailID { get; set; }
        
        
        public PersonalDetails(string name,string fatherName,Gender gender,long mobile,DateTime dob,string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            DOB=dob;
            MailID=mailID;
        }
        
    }
}