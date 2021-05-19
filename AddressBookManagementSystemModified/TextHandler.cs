using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Address_Book
{
    class TextHandler
    {
        const string path = @"C:\Users\SANTANU\source\repos\AddressBookManagementSystem\AddressBookManagementSystemModified\Person.txt";
        public static void WriteToTxt(List<ContactList> contactList)
        {
            //string path = @"C:\Users\SANTANU\source\repos\AddressBookManagementSystem\AddressBookManagementSystemModified\Person.txt";
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(string.Format("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email"));
                foreach (ContactList contact in contactList)
                {
                    tw.WriteLine(string.Format($"{contact.FirstName},{contact.LastName},{contact.Address},{contact.City},{contact.State},{contact.Zip},{contact.PhoneNumber},{contact.Email}"));
                }
            }
        }

        public static List<ContactList> ReadFile(List<ContactList> contactList)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = " ";
                while((s=sr.ReadLine())!=null)
                {
                    Console.WriteLine(s);
                }
            }
            return contactList;
        }
    }
}