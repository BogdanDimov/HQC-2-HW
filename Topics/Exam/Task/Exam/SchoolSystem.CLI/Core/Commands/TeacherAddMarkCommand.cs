using System.Collections.Generic;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherID = int.Parse(parameters[0]);
            var studentID = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = Engine.Students[teacherID];
            var teacher = Engine.Teachers[studentID];
            teacher.AddMark(student, mark);
            var result = $"Teacher {teacher.FirstName} {teacher.LastName} added marks " +
                         $"{mark} to student {student.FirstName} {student.LastName} " +
                         $"in {teacher.Subject}.";
            return result;
        }
    }
}