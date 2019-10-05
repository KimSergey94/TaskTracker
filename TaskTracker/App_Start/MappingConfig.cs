using BLL_TaskTracker.DTO;
using DAL_TaskTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config => 
            {
                config.CreateMap<Task, TaskDTO>();
            });
        }
    }
}