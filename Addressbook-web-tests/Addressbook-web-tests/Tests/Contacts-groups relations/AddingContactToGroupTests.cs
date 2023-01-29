using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        /* First try
        [Test]
        public void AddingContactToGroupTest()
        {
            app.Groups.CreateGroupIfNoneExists();
            app.Contacts.CreateContactIfNoneExists();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
        */

        [Test]
        public void AddingContactToGroupTest2()
        {
            app.Groups.CreateGroupIfNoneExists();
            app.Contacts.CreateContactIfNoneExists();

            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();
            ContactData contactToMove = new ContactData();
            GroupData groupToMoveInto = new GroupData();
            for (int i = 0; i < groups.Count;)
            {
                List<ContactData> contactsOfGroup = groups[i].GetContacts();
                if (contactsOfGroup.Count != contacts.Count)
                {
                    List<ContactData> listContactsToMove = contacts.Except(contactsOfGroup).ToList();
                    contactToMove = listContactsToMove[0];
                    groupToMoveInto = groups[i];
                    break;
                }
                i++;
                if (i == groups.Count)
                {
                    app.Groups.Create(new GroupData("leo"));
                    groupToMoveInto = GroupData.GetAll().Except(groups).First();
                    contactToMove = contacts[0];
                    break;
                }
            }
            List<ContactData> oldList = groupToMoveInto.GetContacts();

            app.Contacts.AddContactToGroup(contactToMove, groupToMoveInto);

            List<ContactData> newList = groupToMoveInto.GetContacts();
            oldList.Add(contactToMove);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
