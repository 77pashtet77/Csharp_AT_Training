using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstName;
        private string lastName;

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname=" + FirstName + "/nLastname=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            var result = FirstName.CompareTo(other.FirstName);
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (result == 0)
            {
                result = LastName.CompareTo(other.LastName);
            }
            return result;
        }


        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
    }
}
