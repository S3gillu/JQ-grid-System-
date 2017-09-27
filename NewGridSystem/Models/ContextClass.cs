using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewGridSystem.Models
{
    public class ContextClass : DbContext
    {

        public ContextClass()
                        : base("Emp")
        {
        }
        public DbSet<NewCustomer> NewCustomers { get; set; }
    }
}