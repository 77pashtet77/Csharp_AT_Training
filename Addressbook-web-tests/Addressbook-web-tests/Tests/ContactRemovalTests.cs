using System;
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
            app.Contacts.CreateContactIfNoneExists().Remove(1, true);
        }

        [Test]
        public void DeclineContactRemovalTest()
        {
            app.Contacts.CreateContactIfNoneExists().Remove(1, false);
        }

        [Test]
        public void ContactRemovalThroghUpdateTest()
        {
            app.Contacts.CreateContactIfNoneExists().RemoveContactThroughEdit(1);
        }
    }
}