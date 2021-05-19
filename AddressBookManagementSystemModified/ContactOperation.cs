using Npgsql.TypeHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Address_Book
{
    public class ContactOperation
    {
        private List<ContactList> ContactLists = new List<ContactList>();
        private Dictionary<string, List<ContactList>> CitiesDict = new Dictionary<string, List<ContactList>>();
        private Dictionary<string, List<ContactList>> StatesDict = new Dictionary<string, List<ContactList>>();
        public void generateData()
        {
          
            ContactLists = JSONHandler.GetDataFromJson();
           
            filterCityState(ContactLists);
            
        }
        
        public void Write()
        {
            CSVHandler.WriteToCSVFile(ContactLists);
            TextHandler.WriteToTxt(ContactLists);
            JSONHandler.WriteToJson(ContactLists);
        }
        public bool checkDuplicate(string firstName)
        {
            bool flag = false;
            foreach (ContactList contact in ContactLists)
            {
                if (contact.FirstName.ToLower() == firstName.ToLower())
                {
                    flag = true;
                    Console.WriteLine("Contact already exist.Please Enter a Different Name");
                    break;
                }
            }
            if (flag) return true;
            else return false;
        }
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            ContactList newContact = new ContactList(firstName, lastName, address, city, state, zip, phoneNumber, email);
            this.ContactLists.Add(newContact);
            filterCityState(ContactLists);
            Write();

        }
        public void ShowOneContact(string fName)
        {
            bool flag = false;
            foreach (var contact in ContactLists)
            {
                if (contact.FirstName.ToLower() == fName.ToLower())
                {
                    flag = true;
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" FirstName: " + contact.FirstName);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" LastName: " + contact.LastName);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" Address: " + contact.Address);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" City: " + contact.City);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" State: " + contact.State);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" ZipCode: " + contact.Zip);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" Phone Number: " + contact.PhoneNumber);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine(" Email: " + contact.Email);
                    Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                }
            }
            if (flag == false)
                Console.WriteLine(" Contact is not found!!");
        }
        public void showList()
        {
            foreach (var contact in ContactLists)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" FirstName: " + contact.FirstName);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" LastName: " + contact.LastName);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" Address: " + contact.Address);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" City: " + contact.City);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" State: " + contact.State);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" ZipCode: " + contact.Zip);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" Phone Number: " + contact.PhoneNumber);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                Console.WriteLine(" Email: " + contact.Email);
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            }
        }
        public void editContact(string fName)
        {
            bool flag = false;
            foreach (var contact in ContactLists)
            {
                if (contact.FirstName.ToLower() == fName.ToLower())
                {
                    flag = true;
                    Console.WriteLine("Old FirstName: " + contact.FirstName);
                    string newFirstName = Console.ReadLine();
                    Console.WriteLine(" Old LastName: " + contact.LastName);
                    string newLastName = Console.ReadLine();
                    Console.WriteLine(" Old Address: " + contact.Address);
                    string newAddress = Console.ReadLine();
                    Console.WriteLine(" Old City: " + contact.City);
                    string newCity = Console.ReadLine();
                    Console.WriteLine(" Old State: " + contact.State);
                    string newState = Console.ReadLine();
                    Console.WriteLine(" Old ZipCode: " + contact.Zip);
                    string newZip = Console.ReadLine();
                    Console.WriteLine(" Old Phone Number: " + contact.PhoneNumber);
                    string newPhoneNumber = Console.ReadLine();
                    Console.WriteLine(" Old Email: " + contact.Email);
                    string newEmail = Console.ReadLine();


                    if (newFirstName != "")
                    {
                        contact.FirstName = newFirstName;
                    }
                    if (newLastName != "")
                    {
                        contact.LastName = newLastName;
                    }
                    if (newAddress != "")
                    {
                        contact.Address = newAddress;
                    }
                    if (newCity != "")
                    {
                        contact.City = newCity;
                        filterCityState(ContactLists);
                    }
                    if (newState != "")
                    {
                        contact.State = newState;
                        filterCityState(ContactLists);
                    }
                    if (newZip != "")
                    {
                        contact.Zip = newZip;
                    }
                    if (newPhoneNumber != "")
                    {
                        contact.PhoneNumber = newPhoneNumber;
                    }
                    if (newEmail != "")
                    {
                        contact.Email = newEmail;
                    }
                    Write();
                }
            }
            if (flag == false) Console.WriteLine(" Contact not found!!");
        }
        public void deleteContact(string fname)
        {
            foreach (var contact in ContactLists)
            {
                if (contact.FirstName.ToLower() == fname.ToLower())
                {
                    ContactLists.Remove(contact);
                    Console.WriteLine("Contact has been deleted!!");
                    filterCityState(ContactLists);
                    Write();
                    break;
                }
            }
        }
        public void addCityList(ContactList contact)
        {
            string key = contact.City;
            ContactList value = contact;
            if (CitiesDict.ContainsKey(key))
            {
                CitiesDict[key].Add(value);
            }
            else
            {
                List<ContactList> contactList = new List<ContactList>();
                CitiesDict.Add(key, contactList);
                CitiesDict[key].Add(value);
            }
        }
        public void addStateList(ContactList contact)
        {
            string key = contact.State;
            ContactList value = contact;
            if (StatesDict.ContainsKey(key))
            {
                StatesDict[key].Add(value);
            }
            else
            {
                List<ContactList> contactList = new List<ContactList>();
                StatesDict.Add(key, contactList);
                StatesDict[key].Add(value);
            }
        }
        public void searchCityOrState(string key)
        {
            try
            {
                List<ContactList> list;
                if (CitiesDict.ContainsKey(key))
                {
                    list = CitiesDict[key];
                }
                else
                {
                    list = StatesDict[key];
                }
                foreach (var contact in list)
                {

                    Console.WriteLine($" {contact.FirstName} {contact.LastName} [{contact.City}] [{contact.State}]");
                }

                Console.WriteLine("Total Count: " + list.Count);

            }
            catch (Exception)
            {
                Console.WriteLine("No Contact with this City or State");
            }
        }
        public void filterCityState(List<ContactList> ContactLists)
        {
            CitiesDict.Clear();
            StatesDict.Clear();
            foreach (var contact in ContactLists)
            {
                addCityList(contact);
                addStateList(contact);
            }
        }
    }
}