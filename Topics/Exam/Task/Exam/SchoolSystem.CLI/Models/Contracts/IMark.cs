using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    public interface IMark
    {
        float Value { get; }

        Subject Subject { get; }
    }
}
