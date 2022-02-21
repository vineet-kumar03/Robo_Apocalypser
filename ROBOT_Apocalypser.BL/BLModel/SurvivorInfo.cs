using System.Collections.Generic;

namespace ROBOT_Apocalypse.BL.BLModel
{
    public class SurvivorInfo
    {
        public SurvivorInfo()
        {
            Inventories = new HashSet<InventoryInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string SurvivorId { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }

        public  ICollection<InventoryInfo> Inventories { get; set; }
    }
}
