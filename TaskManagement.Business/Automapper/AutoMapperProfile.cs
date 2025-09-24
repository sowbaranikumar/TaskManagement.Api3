using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using TaskManagement.Entity.Entities;
using TaskManagement.Business.DTOs;

namespace TaskManagement.Business.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
        }
    }
}

