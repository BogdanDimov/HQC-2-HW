using System.Collections.Generic;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    public interface IStudent
    {
        string FirstName { get; }

        string LastName { get; }

        Grade Grade { get; }

        List<IMark> Marks { get; set; }

        string ListMarks();
    }
}
