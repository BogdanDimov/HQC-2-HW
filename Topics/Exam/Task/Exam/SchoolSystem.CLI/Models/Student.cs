using System.Collections.Generic;
using System.Linq;
using SchoolSystem.CLI.Models.Enums;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Models
{
    public class Student
    {
        public Student(string first, string last, Grade grade)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public string FirstName { get; }

        public string LastName { get; }

        public Grade Grade { get; }

        public List<IMark> Marks { get; set; }

        public string ListMarks()
        {
            var marks = this.Marks.Select(m => $"{m.Subject} => {m.Value}").ToList();
            if (marks.Count != 0)
            {
                return string.Join("\n", marks);
            }

            return "No marks to show!";
        }
    }
}
