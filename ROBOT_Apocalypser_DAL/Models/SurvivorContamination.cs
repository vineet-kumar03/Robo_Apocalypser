using System;
using System.Collections.Generic;

#nullable disable

namespace ROBOT_Apocalypse_DAL.Models
{
    public partial class SurvivorContamination
    {
        public int Id { get; set; }
        public string SurvivorId { get; set; }
        public string ReporterSurvivorId { get; set; }
    }
}
