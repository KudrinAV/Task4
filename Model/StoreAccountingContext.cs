namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreAccountingContext : DbContext
    {
        public StoreAccountingContext()
            : base("name=StoreAccountingContext")
        {
        }
    }
}