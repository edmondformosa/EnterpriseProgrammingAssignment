using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EnterpriseProgrammingAssignment.Models
{
    public class NewDbContext : DbContext
    {
        public NewDbContext() : base("Defaultconnection")
        {
        }

        public DbSet<Categories> categories { get; set; }
        public DbSet<Quality> qualities{ get; set; }
        public DbSet<ItemTypes> itemTypes { get; set; }
        public DbSet<ItemDetails> itemDetails{ get; set; }

    }
}