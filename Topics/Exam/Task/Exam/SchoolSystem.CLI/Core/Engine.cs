using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException("Reader cannot be null or empty.");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException("Writer cannot be null or empty.");
            }

            if (parserProvider == null)
            {
                throw new ArgumentNullException("Parser cannot be null or empty.");
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;

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
                    var commandString = this.reader.ReadLine();
                    if (commandString == "End")
                    {
                        break;
                    }

                    this.ProcessCommand(commandString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandString)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandString);
            var parameters = this.parser.ParseParameters(commandString);

            var executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}