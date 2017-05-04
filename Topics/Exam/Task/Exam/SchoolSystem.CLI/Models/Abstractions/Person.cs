using System;
using System.Text.RegularExpressions;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Models.Abstractions
{
    public class Person : IPerson
    {
        private const int MinLength = 2;
        private const int MaxLength = 31;
        private readonly Regex re = new Regex(@"^[a-zA-Z]+$"); // latin letters only

        public Person(string firstName, string lastName)
        {
            if (firstName.Length < MinLength || firstName.Length > MaxLength)
            {
                throw new ArgumentException("First name must be between 2 and 31 symbols.");
            }

            if (lastName.Length < MinLength || lastName.Length > MaxLength)
            {
                throw new ArgumentException("Last name must be between 2 and 31 symbols.");
            }

            if (!this.re.IsMatch(firstName) || !this.re.IsMatch(lastName))
            {
                throw new ArgumentException("First and last name must consist of latin letters only.");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
