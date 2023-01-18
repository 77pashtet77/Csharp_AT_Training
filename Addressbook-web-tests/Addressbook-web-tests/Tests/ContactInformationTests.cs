using System;
using System.Collections.Generic;
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
            ContactData infoFromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData infoFromForm = app.Contacts.GetContactInformationFromForm(0);

            //verifications
            Assert.AreEqual(infoFromTable, infoFromForm);
            Assert.AreEqual(infoFromTable.Address, infoFromForm.Address);
            Assert.AreEqual(infoFromTable.AllPhones, infoFromForm.AllPhones);

        }
    }
}
