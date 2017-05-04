using System;
using SchoolSystem.CLI.Models.Abstractions;
using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models
{
    public class Teacher : Person, ITeacher
    {
        public Teacher(string first, string last, Subject subj)
            : base(first, last)
        {
            this.Subject = subj;
        }

        public Subject Subject { get; }

        public void AddMark(IStudent stud, float mark)
        {
            if (stud.Marks.Count >= 20)
            {
                throw new InvalidOperationException("Cannot add more than 20 marks to a student.");
            }

            var newMark = new Mark(this.Subject, mark);
            stud.Marks.Add(newMark);
        }
    }
}
