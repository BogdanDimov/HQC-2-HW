using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    public interface ITeacher
    {
        string FirstName { get; }

        string LastName { get; }

        Subject Subject { get; }

        void AddMark(IStudent stud, float val);
    }
}
