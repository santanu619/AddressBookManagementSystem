using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagementSystem
{
    class AddressBook
    {
        private List<Insert_Details> addresses;

        public AddressBook()
        {
            this.addresses = new List<Insert_Details>();
        }

        public void add(string firstName, string lastName, string address, string city, string state, string zip, string phone_number, string email)
        {
            Insert_Details addr = new Insert_Details(firstName, lastName, address, city, state, zip, phone_number, email);
            this.addresses.Add(addr);
        }
        public void showList()
        {
            foreach (var Insert_Details in addresses)
            {
                Console.WriteLine("FirstName:" + Insert_Details.FirstName);
                Console.WriteLine("LastName:" + Insert_Details.LastName);
                Console.WriteLine("Address:" + Insert_Details.Address);
                Console.WriteLine("City:" + Insert_Details.City);
                Console.WriteLine("State:" + Insert_Details.State);
                Console.WriteLine("Zip:" + Insert_Details.Zip);
                Console.WriteLine("PhoneNumber:" + Insert_Details.PhoneNumber);
                Console.WriteLine("Email:" + Insert_Details.Email);
            }
        }
        public void editContact(string fName)
        {
            foreach (var Insert_Details in addresses)
            {
                if (Insert_Details.FirstName == fName)
                {
                    Console.WriteLine("Edit? Old FirstName:" + Insert_Details.FirstName);
                    string newFirstName = Console.ReadLine();
                    Console.WriteLine("Edit? Old LastName:" + Insert_Details.LastName);
                    string newLastName = Console.ReadLine();
                    Console.WriteLine("Edit? Old Address:" + Insert_Details.Address);
                    string newAddress = Console.ReadLine();
                    Console.WriteLine("Edit? Old City:" + Insert_Details.City);
                    string newCity = Console.ReadLine();
                    Console.WriteLine("Edit? Old State:" + Insert_Details.State);
                    string newState = Console.ReadLine();
                    Console.WriteLine("Edit? Old Zip:" + Insert_Details.Zip);
                    string newZip = Console.ReadLine();
                    Console.WriteLine("Edit? Old PhoneNumber:" + Insert_Details.PhoneNumber);
                    string newPhoneNumber = Console.ReadLine();
                    Console.WriteLine("Edit? Old Email:" + Insert_Details.Email);
                    string newEmail = Console.ReadLine();

                    if (newFirstName != "")
                    {
                        Insert_Details.FirstName = newFirstName;
                    }
                    if (newLastName != "")
                    {
                        Insert_Details.LastName = newLastName;
                    }
                    if (newAddress != "")
                    {
                        Insert_Details.Address = newAddress;
                    }
                    if (newCity != "")
                    {
                        Insert_Details.City = newCity;
                    }
                    if (newState != "")
                    {
                        Insert_Details.State = newState;
                    }
                    if (newZip != "")
                    {
                        Insert_Details.Zip = newZip;
                    }
                    if (newPhoneNumber != "")
                    {
                        Insert_Details.PhoneNumber = newPhoneNumber;
                    }
                    if (newEmail != "")
                    {
                        Insert_Details.Email = newEmail;
                    }
                }
            }
        }
        public void deleteContact(string fName)
        {
            foreach (var Insert_Details in addresses)
            {
                if (Insert_Details.FirstName == fName)
                {
                    addresses.Remove(Insert_Details);
                    Console.WriteLine("Contact deleted successfully!");
                    break;
                }
            }
        }
    }
}