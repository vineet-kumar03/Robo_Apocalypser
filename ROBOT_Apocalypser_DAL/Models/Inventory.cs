using System;
using System.Collections.Generic;

#nullable disable

namespace ROBOT_Apocalypse_DAL.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string InventoryName { get; set; }
        public int NoOfDays { get; set; }
        public int SurvivorId { get; set; }

        public virtual Survivor Survivor { get; set; }
    }
}
