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

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void DeclineContactRemovalTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Remove(0, false);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemovalThroghUpdateTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.RemoveContactThroughEdit(0);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}