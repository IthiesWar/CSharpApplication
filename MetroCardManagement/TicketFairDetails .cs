using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFairDetails 
    {
       
    private static int s_ticketID=3001;
    public string TicketID { get;  }//get only property
    public string FromLocation { get; set; }
    
    public string ToLocation { get; set; }
    
    public int TicketPrice { get; set; }
    
    
    public TicketFairDetails(string fromLocation,string toLocation,int ticketPrice)
    {
        TicketID="MR"+s_ticketID++;
        FromLocation=fromLocation;
        ToLocation=toLocation;
        TicketPrice=ticketPrice;
    } 
    public TicketFairDetails(string ticket1)//Filehandlig read object creation
    {
        string[]values=ticket1.Split(",");
        TicketID=values[0];
        FromLocation=values[1];
        ToLocation=values[2];
        TicketPrice=int.Parse(values[3]);
    } 
    }
}