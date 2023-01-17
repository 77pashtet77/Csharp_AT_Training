using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Remove(0, true);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            //saving old groups list state before removal
            ContactData toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            //checking if there is no element with same ID in the list
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void DeclineContactRemovalTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Remove(0, false);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemovalThroghUpdateTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.RemoveContactThroughEdit(0);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            //saving old groups list state before removal
            ContactData toBeRemoved = oldContacts[0];

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            //checking if there is no element with same ID in the list
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}