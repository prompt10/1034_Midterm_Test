using System;
using System.Collections.Generic;

namespace Second_Question_Library_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Preparing the input for user
            string inputUsername, inputPassword, inputType, inputID;

            User user = new User();

            //Preparing books
            Book book1 = new Book(1, "NOW I UNDERSTAND");
            Book book2 = new Book(2, "REVOLUTIONARY WEALTH");
            Book book3 = new Book(3, "Six Degrees");
            Book book4 = new Book(4, "Les Vancances");

        //For the inevitable goto
        MainPage:
            //^ MainPage:
            Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.Write("Select Menu:");
            string decision = Console.ReadLine();
            Console.Clear();

            //register page
            if (decision == "2")
            {
                Console.WriteLine("Register new Person");
                Console.WriteLine("-------------------");
                //Inputing the required information section
                Console.Write("Input name: ");
                inputUsername = Console.ReadLine();
                user.addUser(inputUsername);
                Console.Write("Input Password: ");
                inputPassword = Console.ReadLine();
                user.addPassword(inputPassword);
                Console.Write("Input User Type 1 = Student, 2 = Employee: ");
                inputType = Console.ReadLine();
                user.addType(inputType);

                //Separating the child among men
                if (inputType == "1")
                {
                    Console.Write("Student ID: ");
                    inputID = Console.ReadLine();
                    user.addID(inputID);
                }
                //and in vice versa
                if (inputType == "2")
                {
                    Console.Write("Employee ID: ");
                    inputID = Console.ReadLine();
                    user.addID(inputID);
                }
                Console.Clear();
                //"Marty it's time to go back, BACK TO THE FUTURE"
                //"But doc, the mainpage is literally the past"
                //"Don't ruin the mood Marty, GREAT SCOTT. This require 1.44 GigaNanobyte to goto MainPage"
                goto MainPage;

                //login screen
                if (decision == "1")
                {
                    Console.WriteLine("Login Screen");
                    Console.WriteLine("------------");
                    //Putting in the require information
                    Console.Write("Input name: ");
                    string loginUsername = Console.ReadLine();
                    user.addUser(inputUsername);
                    Console.Write("Input Password: ");
                    string loginPassword = Console.ReadLine();

                    //comparing the sequence in both index to check if they're the same or not
                    int index1 = user.username.FindIndex(a => a.Contains(loginUsername));
                    int index2 = user.password.FindIndex(b => b.Contains(loginPassword));
                    string idType = user.type[index1];
                    //Yours truly wiping system
                    Console.Clear();

                    //go to employee page
                    if (index1 == index2 && idType == "2")
                    {
                        Console.WriteLine("Employee Management");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Name: " + user.username[index1]);
                        Console.WriteLine("Employee ID: " + user.ID[index1]);
                        Console.WriteLine("-------------------");
                        Console.WriteLine("1. Get List Books");
                        Console.Write("Input Menu:");
                        //Checking the condition to go to Book List Page
                        string EmPower = Console.ReadLine();
                        if (EmPower == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Book List");
                            Console.WriteLine("---------");
                            Console.WriteLine("Boo ID: " + book1.ID);
                            Console.WriteLine("Boo name: " + book1.name);
                            Console.WriteLine("Boo ID: " + book2.ID);
                            Console.WriteLine("Boo name: " + book2.name);
                            Console.WriteLine("Boo ID: " + book3.ID);
                            Console.WriteLine("Boo name: " + book3.name);
                            Console.WriteLine("Boo ID: " + book4.ID);
                            Console.WriteLine("Boo name: " + book4.name);
                        }
                    }

                    //go to student page
                    if (index1 == index2 && idType == "1")
                    {
                        Console.WriteLine("Student Management");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Name: " + user.username[index1]);
                        Console.WriteLine("Student ID: " + user.ID[index1]);
                        Console.WriteLine("-------------------");
                        Console.WriteLine("1. Borrow Books");
                        Console.Write("Input Menu:");
                        string StuPower = Console.ReadLine();
                        //Checking the condition to go to Book Borrowing Page
                        if (StuPower == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Book List");
                            Console.WriteLine("---------");
                            Console.WriteLine("Boo ID: " + book1.ID);
                            Console.WriteLine("Boo name: " + book1.name);
                            Console.WriteLine("Boo ID: " + book2.ID);
                            Console.WriteLine("Boo name: " + book2.name);
                            Console.WriteLine("Boo ID: " + book3.ID);
                            Console.WriteLine("Boo name: " + book3.name);
                            Console.WriteLine("Boo ID: " + book4.ID);
                            Console.WriteLine("Boo name: " + book4.name);
                            Console.Write("Input Book ID:");
                            List<int> BookBorrowing = new List<int>();
                            //Using list to note the borrowed book(s)
                            string StuBorrowing = "0";
                            do
                            {
                                //Checking if it's exit or just borrowing more
                                StuBorrowing = Console.ReadLine();
                                int StuBorrowingNum = int.Parse(StuBorrowing);
                                BookBorrowing.Add(StuBorrowingNum);
                            }
                            //If the condition is met
                            while (StuBorrowing != "exit");
                            //It starts spittin'
                            for (int i = 0; i < BookBorrowing.Count; i++)
                            {
                                //Using List.Count to show the borrowed book(s)
                                Console.WriteLine("Book ID: " + BookBorrowing[BookBorrowing.Count]);
                            }
                        }
                    }
                }

            }
        }
    }

    class User
    {
        //Using list for theoradically evergrowing registered user 
        public List<string> username = new List<string>();
        public List<string> password = new List<string>();
        public List<string> type = new List<string>();
        public List<string> ID = new List<string>();

        //4 of these below are for putting those list in... you guess it... list.
        public void addUser(string inputUsername)
        {
            username.Add(inputUsername);
        }
        public void addPassword(string inputPassword)
        {
            password.Add(inputPassword);
        }
        public void addType(string inputType)
        {
            type.Add(inputType);
        }
        public void addID(string inputID)
        {
            ID.Add(inputID);
        }

    }

    //Book Book Book
    //Keeping books with 2d so you really need 1 line where you might need 2
    class Book
    {
        public int ID;
        public string name;

        public Book(int valueID, string valueName)
        {
            ID = valueID;
            name = valueName;
        }

    }
}
