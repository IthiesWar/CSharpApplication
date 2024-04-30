using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class Vaccination
    {
        /*Properties:
•	VaccinationID (Auto increment – VID3001)
•	Registration Number (Beneficiary Reg. num)
•	VaccineID
•	DoseNumber – (1,2,3)
•	Vaccinated Date (DateTime.Now)
*/
    private static int s_vaccinationID=3001;
    public string VaccinationID { get; set; }
    
    public string RegisterNumber { get; set; }
    
    public string VaccineID { get; set; }
    
    public int DoseNumber { get; set; }
    
    public DateTime VaccinatedDate { get; set; }
    
    
    public Vaccination(string registerNumber,string vaccineID,int doseNumber,DateTime vaccinatedDate)
    {
        VaccinationID="VID"+s_vaccinationID++;
        RegisterNumber=registerNumber;
        VaccineID=vaccineID;
        DoseNumber=doseNumber;
        VaccinatedDate=vaccinatedDate;
    }
    }
}