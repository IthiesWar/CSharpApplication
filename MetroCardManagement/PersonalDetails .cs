using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails 
    {
        
    public string UserName { get; set; }//properties
    
    public long PhoneNumber { get; set; }//property
    
    public PersonalDetails(string userName,long phoneNumber)//parametraized constructor
    {
        //Assigning the values
        UserName=userName;
        PhoneNumber=phoneNumber;
    }

    }
}