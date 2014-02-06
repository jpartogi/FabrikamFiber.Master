namespace FabrikamFiber.Web.Controllers
{
    using System.Web.Mvc;

    using DAL.Data;
    using DAL.Models;
    using DAL.Services;

    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            //comment
            this.employeeService = employeeService;
        }

        public ViewResult Index()
        {
            return View(this.employeeService.All());
        }

        public ViewResult Details(int id)
        {
            return View(this.employeeService.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                this.employeeService.InsertOrUpdate(employee);
                this.employeeService.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            return View(this.employeeService.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                this.employeeService.InsertOrUpdate(employee);
                this.employeeService.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Delete(int id)
        {
            return View(this.employeeService.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.employeeService.Delete(id);
            this.employeeService.Save();

            return RedirectToAction("Index");
        }
    }
}

