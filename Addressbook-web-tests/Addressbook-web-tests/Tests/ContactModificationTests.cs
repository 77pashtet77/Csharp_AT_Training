using System;
using System.Collections.Generic;
using System.Linq;
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

            ContactData newData = new ContactData("Vasiliy", "Pupkin");

            app.Contacts.CreateContactIfNoneExists().Modify(0, newData);
        }

        [Test]
        public void ContactModificationTestEmptyData()
        {
            ContactData newData = new ContactData("", "");

            app.Contacts.CreateContactIfNoneExists().Modify(0, newData);
        }
    }
}
