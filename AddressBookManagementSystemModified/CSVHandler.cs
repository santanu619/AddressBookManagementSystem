using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Address_Book
{
    class CSVHandler
    {
        const string importFilePath = @"C:\Users\SANTANU\source\repos\AddressBookManagementSystem\AddressBookManagementSystemModified\Person.csv";
        public static void WriteToCSVFile(List<ContactList> contactList)
        {
            //string importFilePath = @"C:\Users\SANTANU\source\repos\AddressBookManagementSystem\AddressBookManagementSystemModified\Person.csv";
           // string exportFilePath = @"C:\Users\SANTANU\source\repos\AddressBookManagementSystem\AddressBookManagementSystemModified\New.csv";
            using (var reader = new StreamReader(importFilePath))
                using (var csvImport = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csvImport.GetRecords<ContactList>().ToList();
                    Console.WriteLine("Read data successfully from Person csv.");
                    foreach (ContactList addressData in records)
                    {
                        Console.WriteLine("\t" + addressData.FirstName);
                        Console.WriteLine("\t" + addressData.LastName);
                        Console.WriteLine("\t" + addressData.Address);
                        Console.WriteLine("\t" + addressData.City);
                        Console.WriteLine("\t" + addressData.State);
                        Console.WriteLine("\t" + addressData.Zip);
                        Console.WriteLine("\t" + addressData.PhoneNumber);
                        Console.WriteLine("\t" + addressData.Email);
                   

                        Console.WriteLine("Reading form Csv file and Write to Csv file");

                        using (var writer = new StreamWriter(importFilePath))
                        using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                
                   
                }
            
        }
        
    }
}