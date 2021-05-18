using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagementSystem
{
    class Insert_Details
    {
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phone_number;
        private string email;


        public Insert_Details(string firstName, string lastName, string address, string city, string state, string zip, string phone_number, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone_number = phone_number;
            this.email = email;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }

        public string PhoneNumber { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
    }
}


