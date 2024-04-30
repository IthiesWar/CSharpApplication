using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public enum Status{
        Initiated,
        Booked,
        Cance
    }
    public class BookingDetails
    {
        //Properties: BookingID {Auto Increment – BID3000}, CustomerID, TotalPrice, DateOfBooking, Booking Status – Default, Initiated, Booked, Cancelled.
        private static int s_bookingID=3000;
        public string BookingID { get;  }
        public string CustomerID { get; set; }
        public int TotalPrice { get; set; }
        
        public DateTime DateOfBooking { get; set; }
        public Status OrderStatus { get; set; }
        
        public BookingDetails(string customerID,int totalPrice,DateTime dateOfBooking,Status orderStatus)
        {
            BookingID="BID"+s_bookingID++;
            CustomerID=CustomerID;
            TotalPrice=totalPrice;
            DateOfBooking=dateOfBooking;
            OrderStatus=orderStatus;
        }
        
        
        
        
        
        
    }
}