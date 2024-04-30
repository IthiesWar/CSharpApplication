using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYNCFUSIONLIBRARY
{
    public enum Status
    {
        Default, 
        Borrowed, 
        Returned 
    }
    public class BorrowDetails
    {
        private static int s_borrowID=2000;
        public string BorrowID { get; set; }
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowDate { get; set; }
        public int  BookCount { get; set; }
        public Status BorrowStatus { get; set; }
        public int PaidFine { get; set; }
        
        
        //Default Constructor
        public BorrowDetails(string bookID,string userID,DateTime borrowDate,int bookCount,Status borrowStatus,int paidFine)
        {
            BorrowID="LB"+s_borrowID++;
            BookID=bookID;
            UserID=userID;
            BorrowDate=borrowDate;
            BookCount=bookCount;
            BorrowStatus=borrowStatus;
            PaidFine=paidFine;
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}