using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public static class FileHandling
    {
        
        public static void Create()
        {
            //Create Directory
            if(!Directory.Exists("OnlineGrocery"))
            {
                Console.WriteLine("Creating Directory...");
                Directory.CreateDirectory("OnlineGrocery");
            }
            //create file
            if(!File.Exists("Customerregistration"))
            {
                Console.WriteLine("Create File....");
                File.Create("OnlineGrocery/Customerregistration.csv").Close();
            }
        }
        
        public static void WriteCsv()
        {
            string [] customers=new string[Operations.customer.Count];
            for(int i=0;i<Operations.customer.Count;i++)
            {
                customers[i]=Operations.customer[i].CustomerID+","+Operations.customer[i].WalletBalance+","+Operations.customer[i].Name+","+Operations.customer[i].FatherName+","+Operations.customer[i].Gender+","+Operations.customer[i].Mobile+","+Operations.customer[i].DOB+","+Operations.customer[i].MailID;
            }
            File.WriteAllLines("OnlineGrocery/Customerregistration.csv",customers);
        }
        public static void ReadCsv()
        {
            string [] customers=File.ReadAllLines("OnlineGrocery/Customerregistration.csv");
            foreach(string customer1 in customers)
            {
                Customerregistration customer2=new Customerregistration(customer1);
                Operations.customer.Add(customer2);
            }
            
        }
    }
}