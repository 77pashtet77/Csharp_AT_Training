using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData group = new ContactData();
            group.FirstName = "Pavel";
            group.LastName = "Murashkov";
            app.Contacts.Create(group);
        }
    }
}
