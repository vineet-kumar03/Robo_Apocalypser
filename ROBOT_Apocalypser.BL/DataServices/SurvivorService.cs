using ROBOT_Apocalypse.BL.BLModel;
using ROBOT_Apocalypse.BL.Interface;
using ROBOT_Apocalypse_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ROBOT_Apocalypse.BL.DataServices
{
    public class SurvivorService : BaseService, ISurvivorService
    {
        public bool AddSurvivor(Survivor survivor)
        {

            if (survivor != null)
            {
                var survivorRepo = Repository<Survivor>();
                survivorRepo.Add(survivor);
                try
                {
                    SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return false;

        }

        public IList<Survivor> GetSurviours(bool isInfected)
        {
            var survivorRepo = Repository<Survivor>();
            try
            {
                var allSurvior = survivorRepo.GetAll().ToList();
                var survivors = allSurvior.Where(x => x.IsInfected == isInfected).ToList();
                return survivors;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int GetSurvioursPercentage(bool isInfected)
        {
            var survivorRepo = Repository<Survivor>();
            try
            {
                var allSurvior = survivorRepo.GetAll().ToList();
                if (allSurvior == null)
                    return 0;

                var survivors = allSurvior.Where(x => x.IsInfected == isInfected).ToList();
                if (survivors == null)
                    return 0;
                float suvivorsCount = survivors.Count();
                float allSuvivorsCount = allSurvior.Count();
                var percent = (suvivorsCount / allSuvivorsCount)*100;
                return (int)percent  ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ReportSurvivorContamination(string survivorId, string reporterSurvivorId)
        {
            var survivorRepo = Repository<Survivor>();
            try
            {
                var allSurvior = survivorRepo.GetAll().ToList();
                var survivor = allSurvior.Where(x => x.SurvivorId == survivorId).SingleOrDefault();
                if (survivor == null)
                    return "No survivor exist for contamination.";

                if (survivor.IsInfected)
                    return "Survivor is already infacted.";

                var reporterSurvivor = allSurvior.Where(x => x.SurvivorId == reporterSurvivorId).SingleOrDefault();
                if (reporterSurvivor == null)
                    return "No survivor exist to contamination.";
                if (reporterSurvivor.IsInfected)
                    return "An infacted Survivor can not report other survior's contamination.";


                var survivorContaminationRepo = Repository<SurvivorContamination>();
                var survivorContaminations = survivorContaminationRepo.GetAll();
                var survivorContaminationObj = survivorContaminations.Where(x => x.ReporterSurvivorId == reporterSurvivorId && x.SurvivorId == survivorId).FirstOrDefault();
                if (survivorContaminationObj != null)
                    return "Survivor is already  contaminated by reporter.";

                int contaminationCount = survivorContaminations.Where(x => x.SurvivorId == survivorId).Count();
                if (contaminationCount == 2)
                {
                    //Mark survivor as infacted
                    survivor.IsInfected = true;
                    survivorRepo.Update(survivor);
                }

                SurvivorContamination objSurvivorContamination = new SurvivorContamination();
                objSurvivorContamination.ReporterSurvivorId = reporterSurvivorId;
                objSurvivorContamination.SurvivorId = survivorId;
                survivorContaminationRepo.Add(objSurvivorContamination);
                SaveChanges();
                return "Survivor has been contaminated.";
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool UpdateSurvivorLocation(SurvivorLocation survivorLocation)
        {
            if (survivorLocation != null)
            {
                var survivorRepo = Repository<Survivor>();
                try
                {
                    var allSurvior = survivorRepo.GetAll().ToList();
                    var survivor = allSurvior.Where(x => x.SurvivorId == survivorLocation.SurvivorId).SingleOrDefault();
                    if (survivor == null)
                        return false;

                    survivor.LocationLat = survivorLocation.LocationLat;
                    survivor.LocationLong = survivorLocation.LocationLong;
                    survivorRepo.Update(survivor);

                    SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return false;
        }
    }
}
