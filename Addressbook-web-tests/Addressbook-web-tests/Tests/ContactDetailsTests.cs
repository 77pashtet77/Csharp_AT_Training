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
    public class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsTest()
        {
            ContactData selectedContact = ContactData.GetAll().ElementAt(0);

            Assert.AreEqual(app.Contacts.GetContactDetails(selectedContact), app.Contacts.GetFormattedDetailsFromEditForm(0));
        }
    }
}