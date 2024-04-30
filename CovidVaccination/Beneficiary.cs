using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum Gender
    {
        male,
        female,
        transgender
    }
    public class Beneficiary
    {
        /*Properties:
a.	Registration Number (Auto Incremented BID1001)
b.	Name
c.	Age
d.	Gender (Enum [Male, Female, Others])
e.	Mobile Number
f.	City
*/
    private static int s_registerNumber=1001;
    public string RegisterNumber { get;  }
    
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public Gender Gender { get; set; }
    
    public long MobileNumber { get; set; }
    
    public string City { get; set; }
    
    public Beneficiary(string name,int age,Gender gender,long mobileNumber,string city)
    {
        RegisterNumber="BID"+s_registerNumber++;
        Name=name;
        Age=age;
        Gender=gender;
        MobileNumber=mobileNumber;
        City=city;
    }
    
    }
}