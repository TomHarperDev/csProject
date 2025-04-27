using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ThomasHarper_Cs_Project.Models
{
    public class CargoHubEmployeeTasks
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string TaskAssignedTo { get; set; }
        public string TaskAssignedBy { get; set; }
    }
}
