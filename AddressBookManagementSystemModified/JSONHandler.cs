using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Address_Book
{
    class JSONHandler
    {
        const string path = @"C:\Users\SANTANU\source\repos\AddressBookManagementSystem\AddressBookManagementSystemModified\Person.json";
        public static void WriteToJson(List<Contact> contactList)
        {
            string JSONResponse = JsonConvert.SerializeObject(contactList);

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(string.Format("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email"));
            }
        }
        public static List<Contact> GetDataFromJson()
        {
            string json = File.ReadAllText(path);
            var contactList = JsonConvert.DeserializeObject<List<Contact>>(json);
            return contactList;
        }
    }
}
