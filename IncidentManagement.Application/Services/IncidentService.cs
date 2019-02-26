using System.Collections.Generic;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Application.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        public IncidentService(IIncidentRepository incidentRepository, ICommentRepository commentRepository, IUserRepository userRepository, ILocationRepository locationRepository)
        {
            _incidentRepository = incidentRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
        }
        public int Create(int createdBy, int assignedTo, string header, string description, int locationId, out string error)
        {
            try
            {
                var getCreatedBy = _userRepository.FindBy(u => u.Id == createdBy).Result;
                var getAssignedTo = _userRepository.FindBy(u => u.Id == assignedTo).Result;
                var getLocation = _locationRepository.FindBy(l => l.Id == locationId).Result;
                var incident = new Incident
                {
                    AssignedTo = getAssignedTo,
                    CreatedBy = getCreatedBy,
                    Header = header,
                    Description = description,
                    Location = getLocation
                };
                _incidentRepository.Add(incident);
                _incidentRepository.SaveChanges();
                error = "";
                return incident.Id;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return 0;
            }

        }

        public IncidentModel Get(int incidentId, out string error)
        {
            try
            {
                var incident = _incidentRepository.FindBy(i => i.Id == incidentId).Result;
                var comments = _commentRepository.GetAll(c => c.Incident.Id == incident.Id).Result;
                var commentsModel = new List<CommentModel>();
                foreach (var comment in comments)
                {
                    commentsModel.Add(new CommentModel
                    {
                        Text = comment.Text,
                        UserId = comment.User?.Id,
                        IncidentId = comment.Incident?.Id
                    });
                }
                error = "";
                return new IncidentModel { Header = incident.Header, AssignedTo = incident.AssignedTo.Id, CreatedBy = incident.CreatedBy.Id, Comments = commentsModel, Description = incident.Description, LocationId = incident.Location.Id };
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }

        public List<IncidentModel> GetAll(out string error)
        {
            try
            {
                var incidents = _incidentRepository.GetAll().Result;
                var incidentsModel = new List<IncidentModel>();
                foreach (var incident in incidents)
                {
                    incidentsModel.Add(new IncidentModel
                    {
                        Id = incident.Id,
                        AssignedTo = incident.AssignedTo?.Id,
                        Comments = null,
                        CreatedBy = incident.CreatedBy?.Id,
                        Description = incident.Description,
                        Header = incident.Header,
                        LocationId = incident.Location?.Id
                    });
                }
                error = "";
                return incidentsModel;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
            
        }
    }
}
