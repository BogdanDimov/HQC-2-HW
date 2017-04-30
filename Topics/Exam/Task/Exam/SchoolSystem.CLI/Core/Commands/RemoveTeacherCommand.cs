using System.Collections.Generic;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            if (Engine.Teachers.Remove(teacherId))
            {
                return $"Teacher with ID {teacherId} was sucessfully removed.";
            }

            return "No teacher found with the id provided.";
        }
    }
}
