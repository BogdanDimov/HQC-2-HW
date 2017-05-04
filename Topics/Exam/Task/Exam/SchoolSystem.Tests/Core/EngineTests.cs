using System;
using NUnit.Framework;
using SchoolSystem.CLI.Core;
using Moq;
using SchoolSystem.CLI.Core.Contracts;
using System.Linq;

namespace SchoolSystem.Tests.Core
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void EngineCtor_ShouldThrowException_WhenInvalidParametersPassed()
        {
            Assert.Throws<ArgumentNullException>(() => new Engine(null, null, null));
        }

        [Test, Timeout(2500)]
        public void Run_ShouldNotFallIntoInfiniteLoop_WhenPassedValidTerminationCommand()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            var terminationCommand = "End";
            reader.Setup(c => c.ReadLine()).Returns(terminationCommand);

            engine.Run();
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        [TestCase("TeacherAddMark 0 0 3")]
        [TestCase("RemoveStudent 0")]
        [TestCase("RemoveTeacher 0")]
        public void Run_ShouldNotThrow_WhenPassedOneValidTerminationCommand(string command)
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            var terminationCommand = "End";
            reader.SetupSequence(c => c.ReadLine())
                .Returns(command)
                .Returns(terminationCommand);

            Assert.DoesNotThrow(() => engine.Run());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Run_ShouldCallWriteLineOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            var terminationCommand = "End";
            reader.SetupSequence(c => c.ReadLine())
                .Returns(command)
                .Returns(terminationCommand);

            engine.Run();

            writer.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Run_ShouldCallParseCommandOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            var terminationCommand = "End";
            reader.SetupSequence(c => c.ReadLine()).Returns(command).Returns(terminationCommand);

            engine.Run();

            parser.Verify(c => c.ParseCommand(command), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Run_ShouldCallParseParametersOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            var terminationCommand = "End";
            reader.SetupSequence(c => c.ReadLine()).Returns(command).Returns(terminationCommand);

            engine.Run();

            parser.Verify(c => c.ParseParameters(command), Times.Once());
        }

        [TestCase("CreateStudent Pesho Peshev 1")]
        [TestCase("CreateTeacher Gosho Vesheff 2")]
        public void Run_ShouldExecuteTheProcessedCommandOnce_WhenPassedOneValidCommandAndOneTerminationCommand(string command)
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var parser = new Mock<IParser>();
            var cmd = new Mock<ICommand>();
            var engine = new Engine(reader.Object, writer.Object, parser.Object);

            var terminationCommand = "End";
            var commandParameters = command.Split(' ').ToList();
            commandParameters.RemoveAt(0);

            reader.SetupSequence(c => c.ReadLine()).Returns(command).Returns(terminationCommand);
            parser.Setup(c => c.ParseCommand(command)).Returns(cmd.Object);
            parser.Setup(c => c.ParseParameters(command)).Returns(commandParameters);

            engine.Run();

            cmd.Verify(c => c.Execute(commandParameters), Times.Once());
        }
    }
}
