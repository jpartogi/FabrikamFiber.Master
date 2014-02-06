namespace FabrikamFiber.Web.Controllers
{
    using System.Web.Mvc;

    using DAL.Data;
    using DAL.Models;
    using DAL.Services;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public ViewResult Index()
        {
            return View(this.customerService.All());
        }

        public ViewResult Details(int id)
        {
            return View(this.customerService.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            //check model state
            if (ModelState.IsValid)
            {
                this.customerService.InsertOrUpdate(customer);
                this.customerService.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            return View(this.customerService.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                this.customerService.InsertOrUpdate(customer);
                this.customerService.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Delete(int id)
        {
            return View(this.customerService.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.customerService.Delete(id);
            this.customerService.Save();

            return RedirectToAction("Index");
        }
    }
}

