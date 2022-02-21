using ROBOT_Apocalypse.BL.BLModel;
using ROBOT_Apocalypse_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBOT_Apocalypse.BL.Interface
{
  public  interface ISurvivorService
    {
        public bool AddSurvivor(Survivor survivor);

        public bool UpdateSurvivorLocation(SurvivorLocation survivorLocation);
        public IList<Survivor> GetSurviours(bool isInfected);
        public int GetSurvioursPercentage(bool isInfected);

        public string ReportSurvivorContamination(string survivorID,string reporterSurvivorId);
    }
}
