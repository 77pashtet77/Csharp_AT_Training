using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Plumbers");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.CreateGroupIfNoneExists();

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //saving old groups list state before modification and sorting
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());
            //remove

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //checking if exact group was edited
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

        [Test]
        public void GroupModificationTestEmptyData()
        {
            GroupData newData = new GroupData("");
            newData.Header = "";
            newData.Footer = "";
            app.Groups.CreateGroupIfNoneExists();

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            //saving old groups list state before modification and sorting
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            //Hashing
            //Remove code below for stable tests
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());
            //remove

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //checking if exact group was edited
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
