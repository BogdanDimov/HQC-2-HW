using System.Collections.Generic;
using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            Engine.Teachers.Add(id, new Teacher(firstName, lastName, subject));
            var result = $"A new teacher with name {firstName} {lastName}," +
                         $" subject {subject} and ID {id++} was created.";

            return result;
        }
    }
}