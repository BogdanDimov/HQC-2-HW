using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchoolSystem.CLI.Contracts;
using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Core
{
    public class Engine
    {
        private readonly IReader readerProvider;
        private readonly IWriter writerProvider;

        // TODO: change param to IReader instead ConsoleReaderProvider
        public Engine(IReader readerProvider, IWriter writerProvider/*, IParser parserProvider*/)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException(nameof(readerProvider));
            }

            this.readerProvider = readerProvider;

            if (writerProvider == null)
            {
                throw new ArgumentNullException(nameof(writerProvider));
            }

            this.writerProvider = writerProvider;
            Students = new Dictionary<int, IStudent>();
            Teachers = new Dictionary<int, ITeacher>();
        }

        public static IDictionary<int, ITeacher> Teachers { get; set; }

        public static IDictionary<int, IStudent> Students { get; set; }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var commandString = this.readerProvider.ReadLine();
                    if (commandString == "End")
                    {
                        break;
                    }

                    var commandName = commandString.Split(' ')[0];
                    var assembly = this.GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(i => i == typeof(ICommand)))
                        .FirstOrDefault(type => type.Name.ToLower().Contains(commandName.ToLower()));

                    if (typeInfo == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var parameters = commandString.Split(' ').ToList();
                    parameters.RemoveAt(0);
                    var command = Activator.CreateInstance(typeInfo) as ICommand;
                    if (command != null)
                    {
                        this.writerProvider.WriteLine(command.Execute(parameters));
                    }
                }
                catch (Exception ex)
                {
                    this.writerProvider.WriteLine(ex.Message);
                }
            }
        }
    }
}