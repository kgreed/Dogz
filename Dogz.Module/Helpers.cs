using Dogz.Module.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogz.Module
{
    public static class Helpers
    {
        public static DogzEFCoreDbContext MakeDbContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<DogzEFCoreDbContext>()
                .UseSqlServer(connectionString)
                .UseChangeTrackingProxies()
                .UseObjectSpaceLinkProxies();

             
            return new DogzEFCoreDbContext(optionsBuilder.Options);
        }

         

    }
}
