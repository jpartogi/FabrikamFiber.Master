namespace FabrikamFiber.Web.Tests.Services
{
    using Xunit;
    using NSubstitute;
    using FluentAssertions;

    using DAL.Data;
    using DAL.Models;
    using DAL.Services;

    public class CustomerServiceTest
    {
        ICustomerRepository customerRepository;
        ICustomerService customerService;

        public CustomerServiceTest()
        {
            customerRepository = Substitute.For<ICustomerRepository>();
            customerService = new CustomerService(customerRepository);
        }

        [Fact]
        public void ShouldFindAll()
        {
            // TODO:Arrange
            customerService.All(); // Act
            // TODO: Assert
        }

        [Fact]
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
