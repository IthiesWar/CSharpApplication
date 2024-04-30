using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class PersonalDetails
    {
        /*
        Properties:
•	Name
•	Age
•	City
•	PhoneNumber

*/
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    
    public PersonalDetails(string name,int age,string city,string phone)
    {
        Name=name;
        Age=age;
        City=city;
        Phone=phone;
    }
    
    
    
    
    
    
    }
}