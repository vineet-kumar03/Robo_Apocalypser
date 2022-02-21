using System;
using System.Collections.Generic;

#nullable disable

namespace ROBOT_Apocalypse_DAL.Models
{
    public partial class Survivor
    {
        public Survivor()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string SurvivorId { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }
        public bool IsInfected { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
