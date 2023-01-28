using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            app.Contacts.CreateContactIfNoneExists();

            ContactData selectedContact = ContactData.GetAll().ElementAt(0);
            
            ContactData infoFromTable = app.Contacts.GetContactInformationFromTable(selectedContact);
            ContactData infoFromForm = app.Contacts.GetContactInformationFromDB(0);

            Assert.AreEqual(infoFromTable, infoFromForm);
            Assert.AreEqual(infoFromTable.Address, infoFromForm.Address);
            Assert.AreEqual(infoFromTable.AllPhones, infoFromForm.AllPhones);
            Assert.AreEqual(infoFromTable.AllEmails, infoFromForm.AllEmails);
        }
    }
}
