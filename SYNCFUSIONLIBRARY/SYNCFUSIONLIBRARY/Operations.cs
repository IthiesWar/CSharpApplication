using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYNCFUSIONLIBRARY
{
    public static class Operations
    {
        static UserDetail UESRLOGGEDID;
        public static List<UserDetail> userlist=new List<UserDetail>();
        public static List<BookDetails> booklist=new List<BookDetails>();
       public static List<BorrowDetails> borrowlist=new List<BorrowDetails>();


        //Main Menu starts
        public static void MainMenu()
        {
            //getting bool for stop the loop
            bool value=true;
            do
            {   
                
                //wecome message
                Console.WriteLine("*********Online Library Management and Book tracking************");
                //printing the content topics
                Console.WriteLine("MainMenu\n1. Registartion\n2. UserLogin\n3. Exit");
                //getting choice
                Console.WriteLine("Enter your choice");
                int mainChoice=int.Parse(Console.ReadLine());
                //swithc case
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("****Resgitration*****");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("****User Login****");
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****Exit****");
                        Console.WriteLine("Successfully Exited");
                        value=false;
                        break;
                    }
                }


            }while(value);//Loop breaker
        }//Mainmenu ends
        

        //Registration Starts
        public static void Registration()
        {
            //Geting the user intput for registration
            Console.Write("Enter your name: ");
            string userName=Console.ReadLine();
            Console.Write("Enter your Gender Male/Female/Transgender: ");
            //enum data type
            Gender gender=(Gender)Enum.Parse(typeof(Gender),Console.ReadLine(),true);
            Console.Write("Enter your Department ECE/EEE/CSE: ");
            //enum data type
            Department department=(Department)Enum.Parse(typeof(Department),Console.ReadLine().ToUpper(),true);
            Console.Write("Enter your mobile number");
            long mobileNumber=long.Parse(Console.ReadLine());
            Console.Write("Enter your Mail id");
            string mailID=Console.ReadLine();
            Console.Write("Enter your wallet balance");
            int walletBalance=int.Parse(Console.ReadLine());

            //creating the object
            UserDetail userobject=new UserDetail(userName,gender,department,mobileNumber,mailID,walletBalance);
            //Adding to the list
            userlist.Add(userobject);
            Console.WriteLine("Registration successfully and your registeration ID "+userobject.UserID);
        }//User Registration Ends

        //User Login
        public static void UserLogin()
        {
            //Ask the user to give Registrationi id
            Console.WriteLine("Registration ID");
            string loginId=Console.ReadLine();
            //foreach loop to check login id match to the userdetail list data
            //Initialize the bool for if login id not found
            bool value=true;
            foreach(UserDetail user in userlist)
            {
                if(loginId.Equals(user.UserID))
                {
                    //store the data to the userlogged ID
                    UESRLOGGEDID=user;
                    SubMenu();
                    value=false;
                    break;

                }
            }
            if(value)
            {
                Console.WriteLine("Invalid ID");
            }
        }//Login Ends here
        
        //Submenu Starts here
        public static void SubMenu()
        {
            //bool for stop the loop
            bool value=true;
            do
            {
                //Display the contents
                Console.WriteLine("SubMenu\n1. Borrow Book\n2. Show Borrowed Historyn\n3. Reurun Books\n4. Wallet Recharge\n5. Exit");
                //Getting choice from the user
                Console.WriteLine("Enter your choice");
                int subMenuChoice=int.Parse(Console.ReadLine());
                //switch case
                switch(subMenuChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("****Borrow Book****");
                        BorrowBook();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("****Show Current user Borrowed Histry");
                        ShowBookHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****Return Books****");
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("****Wallet Recharge*****");
                        WalletExachange();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("****Exit****");
                        Console.WriteLine("Exit Successfully");
                        value=false;
                        break;
                    }
                }
            }while(value);
        }//submenu ends here
        //Borrow Book
        public static void BorrowBook()
        {
            //list of Books available by printing BookID, BookName, AuthorName, BookCount
            foreach (BookDetails book in booklist)
            {
                Console.WriteLine($"{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}");
            }
            Console.WriteLine();
            // Ask the user to pick one book by Asking “Enter Book ID to borrow”
            Console.WriteLine("Enter Book ID");
            string bookID=Console.ReadLine().ToUpper();//Case user print small letters
            //using traversing “BookID” is available or not
            bool value=true;//case book Id not matching
            foreach(BookDetails book in booklist)
            {
                if(bookID.Equals(book.BookID))
                {
                    //user to pick the count of the book
                    //Ask the user to how many number of books he needed
                    Console.WriteLine("Enter the Book Count");
                    int bookCount=int.Parse(Console.ReadLine());
                    if(book.BookCount>0)
                    {
                        //check book availabitlity
                        //traversing the borrow details to check user is have book befor
                        foreach(BorrowDetails borrow in borrowlist)
                        {
                            int count=0;//for check the user is have the book already
                            if(UESRLOGGEDID.UserID.Equals(borrow.UserID))
                            {
                                count++;
                                if(borrow.BookCount>=3)
                                {
                                    Console.WriteLine("You have borrowed books already"+borrow.BookCount+""+UESRLOGGEDID.UserID);
                                }
                            }
                            if(count==0)
                            {
                                if(bookCount<=3)
                                {
                                    DateTime date1=DateTime.Now;
                                    BorrowDetails taken=new BorrowDetails(borrow.BorrowID,book.BookID,DateTime.Now,borrow.BookCount,Status.Borrowed,0);
                                    Console.WriteLine("Borrowd Successfully");
                                }
                            }
                        }
                        
                        
                    }
                    else
                    {
                        //availability date
                        //traversing the BorrowDetails using foreach
                        foreach(BorrowDetails borrow in borrowlist)
                        {
                            if(book.BookID.Equals(borrow.BookID))
                            {
                                DateTime date=borrow.BorrowDate.AddDays(15);
                                Console.WriteLine("Book will be available on "+date.ToString("yyyy/MM,dd"));
                            }   
                        }
                    }
                    
                }
            }
            if(value)
            {
                Console.WriteLine("Invalid Book id Please enter correct ID");
            }

        }//Borrow Book ends here

        //show borrowed book history
        public static void ShowBookHistory()
        {
            //Travering the bookHistry of currenct user
            Console.WriteLine($"{UESRLOGGEDID.UserID}|{UESRLOGGEDID.UserName}|{UESRLOGGEDID.Gender}|{UESRLOGGEDID.Department}|{UESRLOGGEDID.MobileNumber}|{UESRLOGGEDID.MailID}|{UESRLOGGEDID.WalletBalance}");

        } //Show Book History Ends here

        //Return Book
        public static void ReturnBooks()
        {

        }//Return Books Ends here

        //Wallet Exchange
        public static void WalletExachange()
        {
            Console.WriteLine("Enter the Recharge Amount");
            int recharAmount=int.Parse(Console.ReadLine());
            UESRLOGGEDID.Exchange(recharAmount);
            Console.WriteLine("Wallet Balance "+UESRLOGGEDID.WalletBalance);
        }//Wallet Exchange ends here

        
        public static void DefaultData()
        {
            //User Details Parameters and Objects
            UserDetail user1=new UserDetail("Ravichandran",Gender.Male,Department.ECE,9938388333,"ravi@gmail.com",100);
            UserDetail user2=new UserDetail("Priyadharshini",Gender.Female,Department.CSE,9944444455,"priya@gmail.com",150);
            //Adding data to the list
            userlist.AddRange(new List<UserDetail>(){user1,user2});


            //BookDetails parameters and objects
            BookDetails book1=new BookDetails("C#","Author1",3);
            BookDetails book2=new BookDetails("HTML","Author2",5);
            BookDetails book3=new BookDetails("CSS","Author1",3);
            BookDetails book4=new BookDetails("JS","Author1",3);
            BookDetails book5=new BookDetails("TS","Author2",2);
            //Adding data to the list
            booklist.AddRange(new List<BookDetails>(){book1,book2,book3,book4,book5});

            //BorrowDetails parameters and objects
            BorrowDetails borrow1=new BorrowDetails("BID1001","SF3001",new DateTime(10/09/2023),2,Status.Borrowed,0);
            BorrowDetails borrow2=new BorrowDetails("BID1003","SF3001",new DateTime(12/09/2023),1,Status.Borrowed,0);
            BorrowDetails borrow3=new BorrowDetails("BID1004","SF3001",new DateTime(14/09/2023),1,Status.Returned,16);
            BorrowDetails borrow4=new BorrowDetails("BID1002","SF3002",new DateTime(11/09/2023),2,Status.Borrowed,0);
            BorrowDetails borrow5=new BorrowDetails("BID1005","SF3002",new DateTime(09/09/2023),1,Status.Returned,20);
            //Adding data to the list
            borrowlist.AddRange(new List<BorrowDetails>(){borrow1,borrow2,borrow3,borrow4,borrow5});


            //Traversing userdeatils date using foreach
            foreach(UserDetail user in userlist)
            {
                Console.WriteLine($"|{user.UserID}|{user.Gender}|{user.Department}|{user.MobileNumber}|{user.MailID}|{user.WalletBalance}|");
            }
            Console.WriteLine();//For one line distance

            //Traversing bookdetails date using foreach
            foreach(BookDetails book in booklist)
            {
                Console.WriteLine($"{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}");
            }
            Console.WriteLine();//For one line distance

            //Traversing borrowdetails and objects
            foreach(BorrowDetails borrow in borrowlist)
            {
                Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowDate}|{borrow.BorrowStatus}|{borrow.PaidFine}");
            }
            Console.WriteLine();//For one line distance

        }
    }
}