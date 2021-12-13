using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingUsersAndStudents
{
     class User : IComparable
    {
        string firstName;
        string lastName;
        int yearOfBirth;
        string email;

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int YearOfBirth { get { return yearOfBirth; } set { yearOfBirth = value; } }
        public string Email { get { return email; } set { email = value; } }
        

        public User(string firstName, string lastName, int yearOfBirth, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.yearOfBirth = yearOfBirth;
            this.email = email;
        }
        public virtual string printDetail()
        {
            return $"{this.firstName} {this.lastName} {this.yearOfBirth} {this.email}";
        }

        public int CompareTo(object? obj)
        {
           User other = (User)obj;
           if(this.yearOfBirth < other.yearOfBirth) return 1;
           else if(this.yearOfBirth > other.yearOfBirth) return -1;
           else return 0;
        }
    }
}
