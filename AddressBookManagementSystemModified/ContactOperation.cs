using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagementSystemModified
{
    class ContactOperation
    {
        private Dictionary<string, ContactList> ContactLists = new Dictionary<string, ContactList>();
        private Dictionary<string, List<ContactList>> CityDictionary = new Dictionary<string, List<ContactList>>();
        private Dictionary<string, List<ContactList>> StatesDictionary = new Dictionary<string, List<ContactList>>();
        public void GenerateData()
        {
            ContactList data1 = new ContactList("Santanu", "Mohapatra", "Kharabela Nagar", "Bhubaneswar", "Odisha", "751001", "6294476694", "mohapatra.santanu123@gmail.com");
            ContactList data2 = new ContactList("Manoj", "Dash", "Badasankha", "Puri", "Odisha", "743211", "9080706045", "mani_d@xyz.co.in");
            ContactList data3 = new ContactList("Jethalal", "Gada", "Gokuldham Society, Goregaon", "Mumbai", "Maharastra", "823452", "6840045532", "gadajetha@gmail.com");
            ContactList data4 = new ContactList("Richa", "Rich", "Electronic City", "Bangalore", "karnataka", "543221", "9987665432", "richa@technoscy.com");
            ContactLists.Add("Santanu", data1);
            ContactLists.Add("Manoj", data2);
            ContactLists.Add("Jethalal", data3);
            ContactLists.Add("Richa", data4);
            FilterCityState(ContactLists);
        }
        public void AddContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            if (ContactLists.ContainsKey(firstName))
            {
                Console.WriteLine("Contact already exist with same FirstName.");
            }
            else
            {
                ContactList newContact = new ContactList(firstName, lastName, address, city, state, zip, phoneNumber, email);
                this.ContactLists.Add(firstName, newContact);
                FilterCityState(ContactLists);
            }
        }

        public void ShowList()
        {
            foreach (var contact in ContactLists)
            {
                Console.WriteLine("FirstName: " + contact.Value.FirstName);
                Console.WriteLine("LastName: " + contact.Value.LastName);
                Console.WriteLine("Address: " + contact.Value.Address);
                Console.WriteLine("City: " + contact.Value.City);
                Console.WriteLine("State: " + contact.Value.State);
                Console.WriteLine("ZipCode: " + contact.Value.Zip);
                Console.WriteLine("Phone Number: " + contact.Value.PhoneNumber);
                Console.WriteLine("Email: " + contact.Value.Email);
            }
        }
        public void EditContact(string fName)
        {
            foreach (var contact in ContactLists)
            {
                if (contact.Value.FirstName == fName)
                {
                    Console.WriteLine("Old FirstName: " + contact.Value.FirstName);
                    string newFirstName = Console.ReadLine();
                    Console.WriteLine("Old LastName: " + contact.Value.LastName);
                    string newLastName = Console.ReadLine();
                    Console.WriteLine("Old Address: " + contact.Value.Address);
                    string newAddress = Console.ReadLine();
                    Console.WriteLine("Old City: " + contact.Value.City);
                    string newCity = Console.ReadLine();
                    Console.WriteLine("Old State: " + contact.Value.State);
                    string newState = Console.ReadLine();
                    Console.WriteLine("Old ZipCode: " + contact.Value.Zip);
                    string newZip = Console.ReadLine();
                    Console.WriteLine("Old Phone Number: " + contact.Value.PhoneNumber);
                    string newPhoneNumber = Console.ReadLine();
                    Console.WriteLine("Old Email: " + contact.Value.Email);
                    string newEmail = Console.ReadLine();
                    

                    if (newFirstName != "")
                    {
                        contact.Value.FirstName = newFirstName;
                    }
                    if (newLastName != "")
                    {
                        contact.Value.LastName = newLastName;
                    }
                    if (newAddress != "")
                    {
                        contact.Value.Address = newAddress;
                    }
                    if (newCity != "")
                    {
                        contact.Value.City = newCity;
                        FilterCityState(ContactLists);
                    }
                    if (newState != "")
                    {
                        contact.Value.State = newState;
                        FilterCityState(ContactLists);
                    }
                    if (newZip != "")
                    {
                        contact.Value.Zip = newZip;
                    }
                    if (newPhoneNumber != "")
                    {
                        contact.Value.PhoneNumber = newPhoneNumber;
                    }
                    if (newEmail != "")
                    {
                        contact.Value.Email = newEmail;
                    }
                }
            }
        }
        public void DeleteContact(string fname)
        {
            foreach (var contact in ContactLists)
            {
                if (contact.Value.FirstName == fname)
                {
                    ContactLists.Remove(contact.Key);
                    Console.WriteLine("Contact has been deleted!");
                    FilterCityState(ContactLists);
                    break;
                }
            }
        }
        public void AddCityList(ContactList contact)
        {
            string key = contact.City;
            ContactList value = contact;
            if (CityDictionary.ContainsKey(key))
            {
                CityDictionary[key].Add(value);
            }
            else
            {
                List<ContactList> contactList = new List<ContactList>();
                CityDictionary.Add(key, contactList);
                CityDictionary[key].Add(value);
            }
        }
        public void SearchCity(string city)
        {
            try
            {
                List<ContactList> list = CityDictionary[city];
                foreach (var contact in list)
                {
                    Console.WriteLine(" FirstName: " + contact.FirstName);
                }
                Console.WriteLine("Number of contacts in the city: " + list.Count);
            }
            catch (Exception)
            {
                Console.WriteLine("No Contacts are found within this City in the database.");
            }

        }
        public void AddStateList(ContactList contact)
        {
            string key = contact.State;
            ContactList value = contact;
            if (StatesDictionary.ContainsKey(key))
            {
                StatesDictionary[key].Add(value);
            }
            else
            {
                List<ContactList> contactList = new List<ContactList>();
                StatesDictionary.Add(key, contactList);
                StatesDictionary[key].Add(value);
            }
        }
        public void SearchState(string state)
        {
            try
            {
                List<ContactList> list = StatesDictionary[state];
                foreach (var contact in list)
                {
                    Console.WriteLine("FirstName: " + contact.FirstName);
                }
                Console.WriteLine("Number of contacts in the State: " + list.Count);
            }
            catch (Exception)
            {
                Console.WriteLine("No Contacts are found within this City in the database.");
            }

        }
        public void FilterCityState(Dictionary<string, ContactList> ContactLists)
        {
            CityDictionary.Clear();
            StatesDictionary.Clear();
            foreach (var contact in ContactLists)
            {
                AddCityList(contact.Value);
                AddStateList(contact.Value);
            }
        }
    }
}
