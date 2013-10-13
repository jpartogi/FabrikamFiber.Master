namespace FabrikamFiber.Extranet.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FabrikamFiber.Extranet.Web.Helpers;
    using Xunit;

    public class GuardTest
    {
        [Xunit.Fact]
        public void ItShouldThrowExceptionIfArgumentIsNull()
        {
            try
            {
                Guard.ThrowIfNull(null, "value");
            }
            catch (ArgumentNullException)
            { }
        }

        [Xunit.Fact]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNull()
        {
            Guard.ThrowIfNull("this is not null", "value");
        }

        [Xunit.Fact]
        public void ItShouldThrowExceptionIfArgumentIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                {
                    Guard.ThrowIfNullOrEmpty(string.Empty, "value");
                }
            );
        }

        [Xunit.Fact]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNullOrEmpty()
        {
            Guard.ThrowIfNullOrEmpty("not null or empty", "value");
        }

        [Xunit.Fact]
        public void ItShouldThrowExceptionIfArgumentIsNotInRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate
                {
                    Guard.ThrowIfNotInRange(1, 2, 3, "value");
                }
            );
        }

        [Xunit.Fact]
        public void ItShouldNotThrowExceptionIfArgumentIsNotLesserThanTheMin()
        {
            Guard.ThrowIfNotInRange(2, 1, 3, "value");
        }
    }
}
