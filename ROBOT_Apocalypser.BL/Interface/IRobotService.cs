using ROBOT_Apocalypse.BL.BLModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROBOT_Apocalypse.BL.Interface
{
  public  interface IRobotService
    {
         Task<IList<RobotInfo>> GetAllRobots();
    }
}
