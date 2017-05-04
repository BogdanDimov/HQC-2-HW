using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.Tests.Models
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void StudentCtorThrowsException_WhenAssigningInvalidGrade()
        {
            //arrange, act & assert
            Assert.Throws<ArgumentException>(() => new Student("Koko", "Doko", (Grade)13));
        }

        [Test]
        public void StudentCtorAssignsCorrectValues_WhenValidValuesPassed()
        {
            //arrange & act
            var firstName = "Dqdo";
            var lastName = "Koko";
            var grade = (Grade)12;
            var listOfMarks = new List<IMark>();
            var sut = new Student(firstName, lastName, grade);

            //assert
            Assert.AreEqual(firstName, sut.FirstName);
            Assert.AreEqual(lastName, sut.LastName);
            Assert.AreEqual(grade, sut.Grade);
            Assert.AreEqual(listOfMarks, sut.Marks);
        }

        [Test]
        public void ListMarksMethodShouldListMarks_WhenMarksListIsNotEmpty()
        {
            //arrange
            var firstName = "Dqdo";
            var lastName = "Koko";
            var grade = (Grade)12;
            var sut = new Student(firstName, lastName, grade);

            var markMock = new Mock<IMark>();
            markMock.Setup(m => m.Subject).Returns(Subject.Math);
            markMock.Setup(m => m.Value).Returns(5);

            sut.Marks = new List<IMark> { markMock.Object };

            //act
            var listedMarks = sut.ListMarks().ToLower();

            //assert
            StringAssert.Contains("math => 5", listedMarks);
        }

        [Test]
        public void StudentCtor_ThrowsException_WhenPassedFirstAndLastNameAreNotValid()
        {
            //arrange
            var firstName = "P";
            var lastName = "123Koko";
            var grade = (Grade)12;

            //act & assert
            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void StudentCtor_ThrowsException_WhenPassedNamesExceedLengthLimit()
        {
            //arrange
            var firstName = "Pesho";
            var lastName = "dsjnfoasjdkoasjfpalskdaspdjfaokklsadkspajfkasldaspdkadaspkda";
            var grade = (Grade)12;

            //act & assert
            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }
    }
}
