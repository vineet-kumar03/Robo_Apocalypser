using AutoMapper;
using ROBOT_Apocalypse.BL.BLModel;
using ROBOT_Apocalypse_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBOT_Apocalypse.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Inventory, InventoryInfo>().ReverseMap();
            CreateMap<Survivor, SurvivorInfo>().ReverseMap();
        }
    }
}
