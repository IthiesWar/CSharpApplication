using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class Vaccine
    {
       /* Properties:
a.	VaccineID {Auto Incremented ID – CID2001}
b.	VaccineName {Enum – Covishield, Covaccine}
c.	NoOfDoseAvailable*/
    private static int  s_vaccineId=2001;
    public string VaccineID { get; set; }
    public string VaccineName { get; set; }
    
    public int NoOfDoseAvailable { get; set; }
    
    public Vaccine(string vaccineName,int noOfDoseAvailable)
    {
        VaccineID="CID"+s_vaccineId++;
        VaccineName=vaccineName;
        NoOfDoseAvailable=noOfDoseAvailable;
    }
    

    }
}