using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasHarper_Cs_Project.Models
{
    public class CargoHubEntities : DbContext
    {
        public CargoHubEntities() : base("name=CargoHubEntities")
        {
        }

        public DbSet<CargoHubProducts> CargoHubProducts { get; set; }
        public DbSet<CargoHubUsers> CargoHubUsers { get; set; }
        public DbSet<CargoHubEmployeeTasks> CargoHubEmployeeTasks { get; set; }
    }
}
