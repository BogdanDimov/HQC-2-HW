using System.Collections.Generic;
using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var student = new Student(firstName, lastName, grade);
            Engine.Students.Add(id, student);

            var result = $"A new student with name {firstName} {lastName}," +
                         $" grade {grade} and ID {id++} was created.";

            return result;
        }
    }
}
