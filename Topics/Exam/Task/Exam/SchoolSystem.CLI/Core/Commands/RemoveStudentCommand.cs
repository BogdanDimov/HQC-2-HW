using System.Collections.Generic;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            if (Engine.Students.Remove(studentId))
            {
                return $"Student with ID {studentId} was sucessfully removed.";
            }

            return "No student found with the id provided.";
        }
    }
}