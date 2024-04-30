using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBillCalculation
{
    public class EbBill
    {
        static public int EbNumber=1000;
        public string MeterId { get;  }
        public string UserName { get; set; }
        
        public long Phone { get; set; }
        
        public string MailId { get; set; }
        public double Units { get; set; }

        
        public EbBill(string userName,long phone,string mailId,double units)
        {
            MeterId="EB"+EbNumber++;
            UserName=userName;
            Phone=phone;
            MailId=mailId;
            Units=units;
        }        
        
        
        
        
    }
}