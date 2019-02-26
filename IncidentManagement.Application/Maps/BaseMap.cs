using AutoMapper;
using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;

namespace IncidentManagement.Application.Mappings
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Incident, IncidentModel>();
            CreateMap<User, UserModel>();
            CreateMap<Comment, CommentModel>();
            CreateMap<Location, LocationModel>();
            CreateMap<Machine, MachineModel>();            
        }
    }
}
