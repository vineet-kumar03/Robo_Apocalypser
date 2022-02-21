using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ROBOT_Apocalypse.BL.BLModel;
using ROBOT_Apocalypse.BL.Interface;
using System;
using System.Collections.Generic;

namespace ROBOT_Apocalypse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private IRobotService _robotService;

        public RobotController(ILogger<RobotController> logger, IRobotService robotService)
        {
            _robotService = robotService;
        }

        [HttpGet]
        public IList<RobotInfo> GetAllRobots()
        {
            try
            {
                return _robotService.GetAllRobots().Result;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
