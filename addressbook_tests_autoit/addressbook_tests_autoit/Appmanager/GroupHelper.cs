using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public GroupHelper Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
            return this;
        }

        public GroupHelper Delete(int index, bool moveContactsBeforeDelete)
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + index, "");
            InitGroupDelete();
            
            if (moveContactsBeforeDelete)
            {
                aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            }
            else
            {
                aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d51");
                aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            }
            
            CloseGroupsDialogue();
            return this;
        }

        private GroupHelper CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
            aux.WinWait(WINTITLE);
            return this;
        }

        private GroupHelper OpenGroupsDialogue()
        {
            if (aux.WinGetTitle("[active]", "") != GROUPWINTITLE)
            {
                aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
                aux.WinWait(GROUPWINTITLE);
            }
            return this;
        }

        public GroupHelper InitGroupDelete()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait("Delete group");
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i <= int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }
    }
}