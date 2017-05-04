using System;
using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.CLI.Models
{
    public class Mark : IMark
    {
        public Mark(Subject subj, float val)
        {
            if (val < 2 || val > 6)
            {
                throw new ArgumentException("Mark must be between 2 and 6.");
            }

            this.Subject = subj;
            this.Value = val;
        }

        public float Value { get; }

        public Subject Subject { get; }
    }
}
