using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using System.Xml.Serialization;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(15), GenerateRandomString(15))
                {
                //Add for full contact data filling
                /*
                MiddleName = GenerateRandomString(15), 
                Nickname = GenerateRandomString(15), 
                Address = GenerateRandomString(15),
                Company = GenerateRandomString(15), 
                Title = GenerateRandomString(15), 
                HomePhone = GenerateRandomString(15),
                MobilePhone = GenerateRandomString(15),
                WorkPhone = GenerateRandomString(15),
                FaxPhone = GenerateRandomString(15), 
                Email1 = GenerateRandomString(15),
                Email2 = GenerateRandomString(15),
                Email3 = GenerateRandomString(15),
                Birthday = GenerateRandomString(15), 
                Anniversary = GenerateRandomString(15), 
                SecondAddress = GenerateRandomString(15), 
                SecondHomePhone = GenerateRandomString(15), 
                Notes = GenerateRandomString(15)
                */
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"TestData/contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]));
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"TestData/contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"TestData/contacts.json"));
        }

        /*
        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData(range.Cells[i, 1].Value, range.Cells[i, 2].Value));
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }
        */

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = ContactData.GetAll();
            //adding the created contact to the old list
            oldContacts.Add(contact);
            //sorting both lists to match each other
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
