using System;
using System.Collections.Generic;
using System.Reflection;
using SchoolSystem.CLI.Core.Contracts;
using System.Linq;

namespace SchoolSystem.CLI.Core.Providers
{
    public class CommandParserProvider : IParser
    {
        public ICommand ParseCommand(string commandString)
        {
            var commandName = commandString.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
            var command = Activator.CreateInstance(commandTypeInfo) as ICommand;

            return command;
        }

        public IList<string> ParseParameters(string commandString)
        {
            var parameters = commandString.Split(' ').ToList();
            parameters.RemoveAt(0);

            if (parameters.Count == 0)
            {
                return null;
            }

            return parameters;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(i => i == typeof(ICommand)))
                .FirstOrDefault(type => type.Name.ToLower().Contains(commandName.ToLower()));

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
