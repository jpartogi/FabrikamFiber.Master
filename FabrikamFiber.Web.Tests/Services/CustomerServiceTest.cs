namespace FabrikamFiber.Web.Tests.Services
{
    using NUnit.Framework;
    using NSubstitute;
    using FluentAssertions;

    using DAL.Data;
    using DAL.Models;
    using DAL.Services;

    [TestFixture]
    public class CustomerServiceTest
    {
        ICustomerRepository customerRepository;
        ICustomerService customerService;

        [SetUp]
        public void SetUp()
        {
            customerRepository = Substitute.For<ICustomerRepository>();
            customerService = new CustomerService(customerRepository);
        }

        [Test]
        public void ShouldFindAll()
        {
            // TODO:Arrange
            customerService.All(); // Act
            // TODO: Assert
        }

        [Test]
        public void ShouldFindOne()
        {
            int customerId = 1;
            Customer expected = new Customer();
            customerService.Find(customerId).Returns(expected);

            Customer actual = customerService.Find(customerId);

            customerRepository.Received().Find(customerId);
            actual.Should().Be(expected);
        }
    }
}
