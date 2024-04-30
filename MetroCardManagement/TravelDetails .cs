using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails 
    {
       
    private static int s_travelID=2001;//Field
    public string TravelId { get;  }//get only property
    public string CardNumber { get; set; }
    public string FromLocation { get; set; }
    
    public string ToLocation { get; set; }
    
    public DateTime Date { get; set; }
    public int TravelCost { get; set; }
    
    public TravelDetails(string cardNumber,string fromLocation,string toLocation,DateTime date,int travelCost)
    {
        TravelId="TID"+s_travelID++;
        CardNumber=cardNumber;
        FromLocation=fromLocation;
        ToLocation=toLocation;
        Date=date;
        TravelCost=travelCost;
    }
    public TravelDetails(string travelId,string cardNumber,string fromLocation,string toLocation,DateTime date,int travelCost)
    {
        TravelId=travelId;
        CardNumber=cardNumber;
        FromLocation=fromLocation;
        ToLocation=toLocation;
        Date=date;
        TravelCost=travelCost;
    }
    public TravelDetails(string travel1)
    {
        string []values=travel1.Split(",");
        TravelId=values[0];
        CardNumber=values[1];
        FromLocation=values[2];
        ToLocation=values[3];
        Date=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
        TravelCost=int.Parse(values[5]);
    }
    
    
    
    
    }
}