using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ThomasHarper_Cs_Project.Models
{
    public class CargoHubUsers
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool IsUserAdmin { get; set; }
    }
}
