using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RelationalEntityandRotinginWebApi.Models;

namespace RelationalEntityandRotinginWebApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
            public DbSet<Category> Category { get; set; }
            public DbSet<Post> post { get; set; }

           public DbSet<EmployeeRegistration> tbl_registeremp { get; set; }

        
    }
}
