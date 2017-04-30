using System.Collections.Generic;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.Students[int.Parse(parameters[0])].ListMarks();
        }
    }
}