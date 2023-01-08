using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Plumbers");
            newData.Header = "Yerevan plumbers contacts";
            newData.Footer = "Note that not every1 has hands growing from shoulders";
            app.Groups.Modify(1, newData);
        }

        [Test]
        public void EmptyGroupModificationTest()
        {
            GroupData newData = new GroupData("");
            newData.Header = "";
            newData.Footer = "";
            app.Groups.Modify(1, newData);
        }
    }
}
