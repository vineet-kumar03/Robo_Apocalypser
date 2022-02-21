using Newtonsoft.Json;
using ROBOT_Apocalypse.BL.BLModel;
using ROBOT_Apocalypse.BL.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ROBOT_Apocalypse.BL.DataServices
{
    public class RobotService : IRobotService
    {
        public async Task<IList<RobotInfo>> GetAllRobots()
        {
            using (var httpClient = new HttpClient())
            {

               var robotData= await httpClient.GetStringAsync(@"https://robotstakeover20210903110417.azurewebsites.net/robotcpu");
                var robotInfoList=JsonConvert.DeserializeObject<IList<RobotInfo>>(robotData);
                return robotInfoList;
            }

        }

    }
}
