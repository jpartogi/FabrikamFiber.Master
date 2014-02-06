namespace FabrikamFiber.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FabrikamFiber.Web.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class GuardTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldThrowExceptionIfArgumentIsNull()
        {
            ExceptionGuard.ThrowIfNull(null, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNull()
        {
            ExceptionGuard.ThrowIfNull("this is not null", "value");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldThrowExceptionIfArgumentIsNullOrEmpty()
        {
            ExceptionGuard.ThrowIfNullOrEmpty(string.Empty, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNullOrEmpty()
        {
            ExceptionGuard.ThrowIfNullOrEmpty("not null or empty", "value");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItShouldThrowExceptionIfArgumentIsLesserThanZero()
        {
            ExceptionGuard.ThrowIfLesserThanZero(-1, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotLesserThanZero()
        {
            ExceptionGuard.ThrowIfLesserThanZero(1, "value");
        }
    }
}
