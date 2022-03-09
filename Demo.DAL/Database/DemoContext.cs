using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Database
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> opt) : base(opt)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
