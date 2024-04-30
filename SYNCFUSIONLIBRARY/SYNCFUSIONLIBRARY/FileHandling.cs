using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SYNCFUSIONLIBRARY
{
    public static class FileHandling
    {
        //create the Directory
        public static void Create()
        {
            if(!Directory.Exists("SYNCFUSIONLIBRARY"))
            {
                Console.WriteLine("Create library");
                Directory.CreateDirectory("SYNCFUSIONLIBRARY");
            }
            //create file for UserDetails
            if(!File.Exists("UserDetail"))
            {
                Console.WriteLine("Create File...");
                File.Create("SYNCFUSIONLIBRARY/UserDetail.csv").Close();
            }
            //create file for BookDetails
            if(!File.Exists("BookDetails"))
            {
                Console.WriteLine("Create File...");
                File.Create("SYNCFUSIONLIBRARY/BookDetails.csv").Close();
            }
            //create file for BorrowDetails
            if(!File.Exists("BorrowDetails"))
            {
                Console.WriteLine("Create File...");
                File.Create("SYNCFUSIONLIBRARY/BorrowDetails.csv").Close();
            }
        }
        public static void WriteCsv()
        {
            //UserDetails
            string []user=new string[Operations.userlist.Count];
            for(int i=0;i<Operations.userlist.Count;i++)
            {
                user[i]=Operations.userlist[i].UserID+","+Operations.userlist[i].UserName+","+Operations.userlist[i].Gender+","+Operations.userlist[i].Department+","+Operations.userlist[i].MobileNumber+","+Operations.userlist[i].MailID+","+Operations.userlist[i].WalletBalance;

            }
            File.WriteAllLines("SYNCFUSIONLIBRARY/UserDetail.csv",user);
        }
        

        public static void ReadCsv()
        {
            string []user=File.ReadAllLines("SYNCFUSIONLIBRARY/UserDetail.csv");
            foreach(string users2 in user)
            {
                UserDetail users3=new UserDetail(users2);
                Operations.userlist.Add(users3);
            }
            
        }
    }
}