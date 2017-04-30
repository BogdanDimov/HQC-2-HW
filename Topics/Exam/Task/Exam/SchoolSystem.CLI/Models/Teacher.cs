using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models
{
    public class Teacher
    {
        public Teacher(string first, string last, Subject subj)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Subject = subj;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public Subject Subject { get; }

        public void AddMark(IStudent stud, float mark)
        {
            var newMark = new Mark(this.Subject, mark);
            stud.Marks.Add(newMark);
        }
    }
}
