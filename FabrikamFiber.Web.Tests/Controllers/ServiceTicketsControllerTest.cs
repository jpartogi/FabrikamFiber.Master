namespace FabrikamFiber.Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using FabrikamFiber.DAL.Data;
    using FabrikamFiber.DAL.Models;
    using FabrikamFiber.Web.Controllers;
    using FabrikamFiber.Web.ViewModels;
    using NUnit.Framework;
    using NSubstitute;

    [TestFixture]
    public class ServiceTicketsControllerTest
    {
        ICustomerRepository mockCustomerRepo;
        IEmployeeRepository mockEmployeeRepo;
        IServiceTicketRepository mockServiceTicketRepo;
        IServiceLogEntryRepository mockLogEntryRepo;
        IScheduleItemRepository mockScheduleItemRepo;
        ServiceTicketsController controller;
        
        [SetUp]
        public void SetUp()
        {
            mockCustomerRepo = Substitute.For<ICustomerRepository>();
            mockEmployeeRepo = Substitute.For<IEmployeeRepository>();
            mockServiceTicketRepo = Substitute.For<IServiceTicketRepository>();
            mockLogEntryRepo = Substitute.For<IServiceLogEntryRepository>();
            mockScheduleItemRepo = Substitute.For<IScheduleItemRepository>();

            controller = new ServiceTicketsController(
                mockCustomerRepo,
                mockEmployeeRepo,
                mockServiceTicketRepo,
                mockLogEntryRepo,
                mockScheduleItemRepo
            );
        }

        [Test]
        public void ScheduleActionReturnsValidViewModel()
        {
            // Arrange
            mockServiceTicketRepo.FindIncluding(1).ReturnsForAnyArgs(new ServiceTicket { ID = 1 });
            
            // mockEmployeeRepo.SetReturnValue("Find", new Employee { ID = 1 });
            mockEmployeeRepo.Find(1).Returns(new Employee { ID = 1 });
            
            var scheduleItems = new List<ScheduleItem>();
            scheduleItems.Add(new ScheduleItem { ID = 1, });
            mockScheduleItemRepo.AllIncluding().ReturnsForAnyArgs(scheduleItems.AsQueryable<ScheduleItem>());

            // Act
            var result = (ViewResult)controller.Schedule(1, 1, 0);

            // Assert
            var model = result.ViewData.Model as ScheduleViewModel;
            Assert.NotNull(model.Employee);
            Assert.NotNull(model.ScheduleItems);
            Assert.NotNull(model.ServiceTicket);
            controller.ViewBag.StartTime = 0;
        }
        
        [Test]
        public void ScheduleActionCorrectlyUpdatesRepositories()
        {
            // Arrange
            var scheduleItems = new List<ScheduleItem>();
            scheduleItems.Add(new ScheduleItem { ServiceTicketID = 1 });
            mockScheduleItemRepo.All.Returns(scheduleItems.AsQueryable<ScheduleItem>());
         
            ServiceTicket ticket = new ServiceTicket { ID = 0 };
            mockServiceTicketRepo.Find(1).Returns(ticket);

            // Act
            controller.AssignSchedule(1, 101, 0);

            // Assert
            Assert.AreEqual(101, ticket.AssignedToID);
            mockScheduleItemRepo.ReceivedCalls();
            mockServiceTicketRepo.ReceivedCalls();
        }
    }
}