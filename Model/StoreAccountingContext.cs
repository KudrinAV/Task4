namespace Model
{
    using Model.DataModel;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreAccountingContext : DbContext
    {
        public StoreAccountingContext()
            : base("name=StoreAccountingContext")
        {
        }

        public DbSet<ManagerInfo> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}