using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public GroupData() { }

        public string Name { get; set; }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(GroupData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
