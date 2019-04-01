using AutoMapper;
using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using System;

namespace IncidentManagement.Application.Mappings
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Incident, IncidentModel>();
            CreateMap<IncidentModel, Incident>();
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<UserType, UserTypeModel>();
            CreateMap<UserTypeModel, UserType>();
            CreateMap<Comment, CommentModel>();
            CreateMap<CommentModel, Comment>();
            CreateMap<Location, LocationModel>();
            CreateMap<LocationModel, Location>();
            CreateMap<MachineModel, Machine>();
        }
    }
}
