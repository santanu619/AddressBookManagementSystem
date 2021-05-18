using System;
using System.Collections.Generic;
namespace AddressBookManagementSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("Welcome to the Address Book Management System");
            Console.WriteLine("**********************************************");
            AddressBook addressbook = new AddressBook();
            while (true)
            {
                Console.WriteLine("<Please Press the key for the choice>");
                Console.WriteLine("1.Add Contact Details");
                Console.WriteLine("2.Show Contact Details");
                Console.WriteLine("3.Edit Contact Details");
                Console.WriteLine("4.Delete Contact Details");
                Console.WriteLine("5.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Contact Details");
                        Console.WriteLine("First Name:");
                        string firstname = Console.ReadLine();
                        Console.WriteLine("Last Name:");
                        string lastname = Console.ReadLine();
                        Console.WriteLine("Address:");
                        string address = Console.ReadLine();
                        Console.WriteLine("City:");
                        string city = Console.ReadLine();
                        Console.WriteLine("State:");
                        string state = Console.ReadLine();
                        Console.WriteLine("Zip Code:");
                        string zip = Console.ReadLine();
                        Console.WriteLine("Phone Number:");
                        string phone_number = Console.ReadLine();
                        Console.WriteLine("Email:");
                        string email = Console.ReadLine();
                        addressbook.add(firstname, lastname, address, city, state, zip, phone_number, email);
                        break;

                    case 2:
                        addressbook.showList();
                        break;

                    case 3:
                        Console.WriteLine("Enter First Name you want to edit:");
                        string FName = Console.ReadLine();
                        addressbook.editContact(FName);
                        break;

                    case 4:
                        Console.WriteLine("Enter First Name you want to delete:");
                        string Name = Console.ReadLine();
                        addressbook.deleteContact(Name);
                        break;

                    case 5:
                        System.Environment.Exit(1);
                        break;


                }
            }
        }
    }
}