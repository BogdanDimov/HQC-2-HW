using System;
using NUnit.Framework;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Enums;

namespace SchoolSystem.Tests.Models
{
    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void MarkCtorAssignsCorrectValues_WhenInvoked()
        {
            //arrange & act
            var subject = Subject.Bulgarian;
            var mark = 5.0f;
            var sut = new Mark(subject, mark);

            //assert
            Assert.AreEqual(subject, sut.Subject);
            Assert.AreEqual(mark, sut.Value);
        }

        [Test]
        public void MarkCtorThrowsError_WhenPassedValueLessThanTwo()
        {
            // arrange
            var val = 1.0f;
            var subj = Subject.Bulgarian;

            //act & assert
            Assert.Throws<ArgumentException>(() => new Mark(subj, val));
        }

        [Test]
        public void MarkCtorThrowsError_WhenPassedValueBiggerThanSix()
        {
            // arrange
            var val = 7.0f;
            var subj = Subject.Bulgarian;

            //act & assert
            Assert.Throws<ArgumentException>(() => new Mark(subj, val));
        }

        [Test]
        public void MarkCtorDoesNotThrow_WhenValidValuesPassed()
        {
            //arrange & act
            var subject = Subject.Bulgarian;
            var mark = 5.0f;

            //act & assert
            Assert.DoesNotThrow(() => new Mark(subject, mark));
        }
    }
}
