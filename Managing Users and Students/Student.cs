using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingUsersAndStudents
{
     class Student: User
    {
        public string grade;

        public Student(string firstName, string lastName, int yearOfBirth, string email, string grade) : base(firstName, lastName, yearOfBirth, email)
        {
            this.grade = grade;
        }

        public override string printDetail()
        {
           return $"{base.printDetail()} {this.grade}";
        }
    }
}
