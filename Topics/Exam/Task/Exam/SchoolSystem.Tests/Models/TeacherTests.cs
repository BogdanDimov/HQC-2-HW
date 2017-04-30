using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public void TeacherConstructorAssignsCorrectValues()
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
        public void AddMethodAddsMarkWhenInvoked()
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
            Assert.AreEqual(subj, studentMock.Object.Marks.Single().Subject);
            Assert.AreEqual(mark, studentMock.Object.Marks.Single().Value);
        }
    }
}
