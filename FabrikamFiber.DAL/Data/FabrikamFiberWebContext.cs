namespace FabrikamFiber.DAL.Data
{
    using FabrikamFiber.DAL.Data;
    using System.Data.Entity;

    public class FabrikamFiberWebContext : DbContext, IFabrikamFiberWebContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<FabrikamFiber.DAL.Models.FabrikamFiberWebContext>());
        public FabrikamFiberWebContext()
            : base("FabrikamFiber-Express")
        {
        }

        public FabrikamFiberWebContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Models.Customer> Customers { get; set; }

        public IDbSet<Models.Employee> Employees { get; set; }

        public IDbSet<Models.ServiceTicket> ServiceTickets { get; set; }

        public IDbSet<Models.ServiceLogEntry> ServiceLogEntries { get; set; }

        public IDbSet<Models.Message> Messages { get; set; }

        public IDbSet<Models.Alert> Alerts { get; set; }

        public IDbSet<Models.ScheduleItem> ScheduleItems { get; set; }
    }
}