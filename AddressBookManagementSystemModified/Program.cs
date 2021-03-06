using System;

namespace Address_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactOperation contactOperation = new ContactOperation();
            contactOperation.generateData();
            while (true)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("\n");
                Console.WriteLine("\t\t\t\tWELCOME TO ADDRESSBOOK MANAGEMENT SYSTEM\t\t\t\t");
                Console.WriteLine("\n");
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("  Select Choice:");
                Console.WriteLine("*****************");
                Console.WriteLine(" 1. Add Contact ");
                Console.WriteLine("*****************");
                Console.WriteLine(" 2. Show Contacts");
                Console.WriteLine("*****************");
                Console.WriteLine(" 3. Edit Contact ");
                Console.WriteLine("*****************");
                Console.WriteLine(" 4. Delete Contact");
                Console.WriteLine("*****************");
                Console.WriteLine(" 5. Search by City");
                Console.WriteLine("*****************");
                Console.WriteLine(" 6. Search by State");
                Console.WriteLine("*****************");
                Console.WriteLine(" 7. Exit ");
                Console.WriteLine("*****************");


                try
                {

                    int ch = Convert.ToInt32(Console.ReadLine());


                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Add Contact Details:");
                            Console.WriteLine("First Name:");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Address:");
                            string address = Console.ReadLine();
                            Console.WriteLine("City:");
                            string city = Console.ReadLine();
                            Console.WriteLine("State:");
                            string state = Console.ReadLine();
                            Console.WriteLine("Zip Code:");
                            string zip = Console.ReadLine();
                            Console.WriteLine("Phone Number:");
                            string phoneNumber = Console.ReadLine();
                            Console.WriteLine("Email Address:");
                            string email = Console.ReadLine();
                            contactOperation.addContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                            break;

                        case 2:
                            contactOperation.showList();
                            break;

                        case 3:
                            Console.WriteLine("Enter First Name you want to Edit?");
                            string fName = Console.ReadLine();
                            contactOperation.editContact();
                            break;

                        case 4:
                            Console.WriteLine("Enter First Name you want to Delete?");
                            string name = Console.ReadLine();
                            contactOperation.deleteContact(name);
                            break;

                        case 5:
                            Console.WriteLine("Enter City Name?");
                            string cityName = Console.ReadLine();
                            contactOperation.searchCityOrState(cityName);
                            break;

                        case 6:
                            Console.WriteLine("Enter State Name?");
                            string stateName = Console.ReadLine();
                            contactOperation.searchCityOrState(stateName);
                            break;

                        case 7:
                            System.Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine($"{ch} is Invalid Choice!");
                            break;
                    }



                }
               
                catch (Exception) { }
                
                Console.WriteLine("Press key(---____---)");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
