using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
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

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contact);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            //adding the created contact to the old list
            oldContacts.Add(contact);
            //sorting both lists to match each other
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
