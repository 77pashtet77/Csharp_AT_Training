using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactSearchTests : AuthTestBase
    {
        [Test]
        public void SearchTest()
        {
            Assert.AreEqual(app.Contacts.GetNumberOfSearchResults(), app.Contacts.GetContactsCount());
        }
    }
}
