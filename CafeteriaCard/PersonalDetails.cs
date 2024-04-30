using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    //Enum data type
    public enum Gender
    {
        male,
        female,
        transgender
    }
    public class PersonalDetails
    {
      //Properties
    public string Name { get; set; }
    
    public string FatherName { get; set; }
    
    public Gender Gender { get; set; }
    
    public long Mobile { get; set; }
    public string MailID{ get; set; }

    public PersonalDetails(string name,string fatherName,Gender gender,long mobile,string mailID)
    {
        Name=name;
        FatherName=fatherName;
        Gender=gender;
        Mobile=mobile;
        MailID=mailID;
    }
    }
}