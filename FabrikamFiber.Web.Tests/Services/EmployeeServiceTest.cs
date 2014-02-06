namespace FabrikamFiber.Web.Tests.Services
{
    using NUnit.Framework;
    using NSubstitute;
    using FluentAssertions;

    using DAL.Data;
    using DAL.Models;
    using DAL.Services;

    [TestFixture]
    public class EmployeeServiceTest
    {
        IEmployeeRepository employeeRepository;
        IEmployeeService employeeService;

        [SetUp]
        public void SetUp()
        {
            employeeRepository = Substitute.For<IEmployeeRepository>();
            employeeService = new EmployeeService(employeeRepository);
        }

        [Test]
        public void ShouldFindAllEmployees()
        {
            // TODO:Arrange
            employeeService.All(); // Act
            // TODO: Assert
        }

        [Test]
        public void ShouldFindOneEmployee()
        {
            int employeeId = 1;
            Employee expected = new Employee();
            employeeService.Find(employeeId).Returns(expected);

            Employee actual = employeeService.Find(employeeId);

            employeeRepository.Received().Find(employeeId);
            actual.Should().Be(expected);
        }
    }
}
