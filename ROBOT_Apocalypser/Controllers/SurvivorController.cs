using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ROBOT_Apocalypse.BL.BLModel;
using ROBOT_Apocalypse.BL.Interface;
using ROBOT_Apocalypse_DAL.Models;
using System;
using System.Collections.Generic;

namespace ROBOT_Apocalypse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurvivorController : ControllerBase
    {


        private ISurvivorService _survivorService;
        private readonly IMapper _mapper;

        public SurvivorController(ISurvivorService survivorService,IMapper mapper)
        {
            _survivorService = survivorService;
            _mapper = mapper;
        }

        [Route("AddSurvivor")]
        [HttpPost]
        public bool AddSurvivor(SurvivorInfo survivorInfo)
        {
            try
            {
                var survivor = _mapper.Map<Survivor>(survivorInfo);
                return _survivorService.AddSurvivor(survivor);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [Route("UpdateSurvivorLocation")]
        [HttpPatch]
        public bool UpdateSurvivorLocation(SurvivorLocation survivorLocation)
        {
            try
            {
                return _survivorService.UpdateSurvivorLocation(survivorLocation);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("GetInfactedSurviours")]
        [HttpGet]
        public IList<SurvivorInfo> GetInfactedSurviours()
        {
            try
            {
                var survivors = _survivorService.GetSurviours(true);
                return _mapper.Map<IList<SurvivorInfo>>(survivors);
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("GetNonInfactedSurviours")]
        [HttpGet]
        public IList<SurvivorInfo> GetNonInfactedSurviours()
        {
            try
            {
                var survivors= _survivorService.GetSurviours(false);

                return _mapper.Map<IList<SurvivorInfo>>(survivors);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("GetNonInfactedSurvioursPercentage")]
        [HttpGet]
        public int GetNonInfactedSurvioursPercentage()
        {
            try
            {
                return _survivorService.GetSurvioursPercentage(false);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("GetInfactedSurvioursPercentage")]
        [HttpGet]
        public int GetInfactedSurvioursPercentage()
        {
            try
            {
                return _survivorService.GetSurvioursPercentage(true);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("ReportSurvivorContamination")]
        [HttpPost]
        public string ReportSurvivorContamination(string survivorID, string reporterSurvivorId)
        {
            try
            {
                return _survivorService.ReportSurvivorContamination(survivorID,reporterSurvivorId);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
