using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models
{
    public class Mark : IMark
    {
        public Mark(Subject subj, float val)
        {
            this.Subject = subj;
            this.Value = val;
        }

        public float Value { get; }

        public Subject Subject { get; }
    }
}
