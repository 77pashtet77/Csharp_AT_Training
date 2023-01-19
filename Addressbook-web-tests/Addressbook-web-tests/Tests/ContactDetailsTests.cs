using System;
using System.Collections.Generic;
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
            Assert.AreEqual(app.Contacts.GetContactDetails(0), app.Contacts.GetFormattedDetailsFromEditForm(0));
        }
    }
}