using System;

namespace AddressBookManagementSystemModified
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Welcome To The Address Book");
            Console.WriteLine("***************************");

            ContactOperation contactOperation = new ContactOperation();
            contactOperation.GenerateData();
            while (true)
            {
                Console.WriteLine("Select Choice:");
                Console.WriteLine("1.Add Contact");
                Console.WriteLine("2.Show Contacts");
                Console.WriteLine("3.Edit Contact");
                Console.WriteLine("4.Delete Contact");
                Console.WriteLine("5.Search by City");
                Console.WriteLine("6.Search by State");
                Console.WriteLine("7.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Contact Details:-");
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
                        contactOperation.AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                        break;

                    case 2:
                        contactOperation.ShowList();
                        break;

                    case 3:
                        Console.WriteLine("Enter First Name of the Contact You Want to Edit.");
                        string fName = Console.ReadLine();
                        contactOperation.EditContact(fName);
                        break;

                    case 4:
                        Console.WriteLine("Enter First Name of the Contact You Want to Delete.");
                        string name = Console.ReadLine();
                        contactOperation.DeleteContact(name);
                        break;

                    case 5:
                        Console.WriteLine("Enter City Name.");
                        string cityName = Console.ReadLine();
                        contactOperation.SearchCity(cityName);
                        break;

                    case 6:
                        Console.WriteLine("Enter State Name.");
                        string stateName = Console.ReadLine();
                        contactOperation.SearchState(stateName);
                        break;

                    case 7:
                        System.Environment.Exit(1);
                        break;
                }
                //Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }
    }
}