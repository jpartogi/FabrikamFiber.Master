namespace FabrikamFiber.Web.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Xunit;
    using NSubstitute;
    using FluentAssertions;

    using FabrikamFiber.DAL.Data;
    using FabrikamFiber.DAL.Models;
    using FabrikamFiber.DAL.Services;
    using FabrikamFiber.Web.Controllers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class CustomersControllerTest
    {
        ICustomerService customerService;
        CustomersController controller;

        [TestInitialize]	
        public void SetUp()
        {
            customerService = Substitute.For<ICustomerService>();
            controller = new CustomersController(customerService);
        }

        [TestMethod]	
        public void CreateInsertsCustomerAndSaves()
        {
            Customer customer = new Customer();
            controller.Create(customer);

            customerService.Received().InsertOrUpdate(customer);
            customerService.Received().Save();
        }

        [TestMethod]	
        public void CreateNullCustomer()
        {
            controller.Create(null);
        }

        [TestMethod]	
        public void EditUpdatesCustomerAndSaves()
        {
            Customer customer = new Customer();
            controller.Edit(customer);

            customerService.Received().InsertOrUpdate(customer);
            customerService.Received().Save();
        }

        [TestMethod]	
        public void DeleteFindAndReturnsCustomer()
        {
            int customerId = 1;
            customerService.Find(customerId).Returns(new Customer());

            ViewResult result = controller.Delete(customerId) as ViewResult;

            customerService.Received().Find(customerId);
            result.Model.Should().BeOfType<Customer>();
        }

        [TestMethod]	
        public void DeleteConfirmedDeletesCustomerAndSaves()
        {
            int customerId = 1;
            controller.DeleteConfirmed(customerId);

            customerService.Received().Delete(customerId);
            customerService.Received().Save();
        }
    } 
}
