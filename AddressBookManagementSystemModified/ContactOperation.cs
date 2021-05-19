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
            TextHandler.ReadFile();
           
            filterCityState(ContactLists);
            
        }
        
        public void Write()
        {
            CSVHandler.WriteToCSVFile(ContactLists);
            TextHandler.WriteToTxt(ContactLists);
            JSONHandler.WriteToJson(ContactLists);
        }
        
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            ContactList newContact = new ContactList(firstName, lastName, address, city, state, zip, phoneNumber, email);
            this.ContactLists.Add(newContact);
            filterCityState(ContactLists);
            Write();

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
        public void editContact()
        {
            Console.WriteLine("Please Enter Name Which You Want To Edit");
            string Name = Console.ReadLine();
            foreach (var contact in ContactLists)
                if (Name.Equals(contact.FirstName))
                {
                    Console.WriteLine("Enter new FirstName");
                    string NewFirstName = Console.ReadLine();
                    contact.FirstName = NewFirstName;
                }
            Console.WriteLine("Contact is Edited");
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