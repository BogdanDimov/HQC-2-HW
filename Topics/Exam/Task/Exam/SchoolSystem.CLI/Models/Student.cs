using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSystem.CLI.Models.Abstractions;
using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models
{
    public class Student : Person, IStudent
    {
        public Student(string first, string last, Grade grade)
            : base(first, last)
        {
            if ((int)grade < 1 || (int)grade > 12)
            {
                throw new ArgumentException("Grade must be between 1 and 12.");
            }

            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

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
