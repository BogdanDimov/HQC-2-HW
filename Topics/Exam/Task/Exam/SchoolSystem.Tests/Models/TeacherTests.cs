using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.Tests.Models
{
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void TeacherCtorAssignsCorrectValues_WhenPassedValuesAreValid()
        {
            //arrange
            var first = "Pesho";
            var last = "Peshev";
            var subj = Subject.Math;

            //act
            var sut = new Teacher(first, last, subj);

            //assert
            Assert.AreEqual(first, sut.FirstName);
            Assert.AreEqual(last, sut.LastName);
            Assert.AreEqual(subj, sut.Subject);
        }

        [Test]
        public void AddMarkMethodsAddsMark_WhenValidMarkIsPassed()
        {
            //arrange
            var subj = Subject.Programming;
            var mark = 5;
            var teacher = new Teacher("Pesho", "Peshev", subj);
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.Marks).Returns(new List<IMark>());

            //act
            teacher.AddMark(studentMock.Object, mark);

            //assert
            Assert.AreEqual(subj, studentMock.Object.Marks[0].Subject);
            Assert.AreEqual(mark, studentMock.Object.Marks[0].Value);
        }

        [Test]
        public void AddMarkMethodThrowsException_WhenStudentHasReachedTheMarksLimit()
        {
            //arrange
            var sut = new Teacher("Pesho", "Peshev", Subject.Bulgarian);
            var studentMock = new Mock<IStudent>();
            var markMock = new Mock<IMark>();
            var listOfMarks = Enumerable.Repeat(markMock.Object, 20)
                .ToList();
            studentMock.Setup(s => s.Marks).Returns(listOfMarks);

            //act & assert
            Assert.Throws<InvalidOperationException>(() => sut.AddMark(studentMock.Object, 4.5f));
        }

        [Test]
        public void TeacherCtor_ShouldThrowException_WhenPassedFirstAndLastNameAreInvalid()
        {
            //arrange
            var firstName = "U4itelq";
            var lastName = "X";
            var subject = Subject.Programming;

            //act & assert
            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }
    }
}
