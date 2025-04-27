using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ThomasHarper_Cs_Project.Models
{
    public class CargoHubProducts
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductCost { get; set; }
        public string ProductReplenishTime { get; set; }
    }
}
