using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved, true);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = ContactData.GetAll();

            //saving old groups list state before removal

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

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved, false);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = ContactData.GetAll();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemovalThroghUpdateTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = ContactData.GetAll();

            //saving old groups list state before removal
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.RemoveContactThroughEdit(toBeRemoved);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = ContactData.GetAll();

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