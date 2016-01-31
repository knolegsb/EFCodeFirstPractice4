using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstPractice4
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
