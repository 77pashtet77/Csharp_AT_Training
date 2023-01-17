using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            ContactData newData = new ContactData("Pupkin", "Vasiliy");

            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            //saving old contacts list state before modification and sorting
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            //Filling old contact fields with new values
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            //sorting both lists to match each other
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //checking if exact item was edited
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, contact.LastName);
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }
        }

        [Test]
        public void ContactModificationTestEmptyData()
        {
            ContactData newData = new ContactData("", "");

            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            //saving old contacts list state before modification and sorting
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());
            //remove

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            //Filling old contact fields with new values
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            //sorting both lists to match each other
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //checking if exact item was edited
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, contact.LastName);
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }
        }
    }
}
