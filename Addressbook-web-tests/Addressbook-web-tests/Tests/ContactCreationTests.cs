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
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Murashkova", "Xenia");

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

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

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
