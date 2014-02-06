namespace FabrikamFiber.Web.Tests.Controllers
{
    using System.Web.Mvc;
    using FabrikamFiber.DAL.Data;
    using FabrikamFiber.Web.Controllers;
    using NUnit.Framework;
    using Xunit;
    using Xunit.Extensions;
    using NSubstitute;

    [TestFixture]
    public class HomeControllerTest
    {
        IServiceTicketRepository serviceTicketRepo;
        IMessageRepository messageRepo;
        IAlertRepository alertRepo;
        IScheduleItemRepository scheduleItemRepo;
        HomeController controller;

        [SetUp]
        public void SetUp()
        {
            serviceTicketRepo = Substitute.For<IServiceTicketRepository>();
            messageRepo = Substitute.For<IMessageRepository>();
            alertRepo = Substitute.For<IAlertRepository>();
            scheduleItemRepo = Substitute.For<IScheduleItemRepository>();

            controller = new HomeController(
                serviceTicketRepo,
                messageRepo,
                alertRepo,
                scheduleItemRepo
            );
        }

        [Test]
        public void IndexReturnsNonNullView()
        {
            var result = (ViewResult)controller.Index();
        }
    }
}
