using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Address_Book
{
    class TextHandler
    {
        public static void WriteToTxt(List<Contact> contactList)
        {
            string path = @"C:\Users\SANTANU\source\repos\AddressBookManagementSystem\AddressBookManagementSystemModified\Person.txt";
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(string.Format("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email"));
                foreach (Contact contact in contactList)
                {
                    tw.WriteLine(string.Format($"{contact.FirstName},{contact.LastName},{contact.Address},{contact.City},{contact.State},{contact.Zip},{contact.PhoneNumber},{contact.Email}"));
                }
            }
        }
    }
}