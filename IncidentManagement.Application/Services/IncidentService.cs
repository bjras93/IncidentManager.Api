using System;
using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;
        public IncidentService(IIncidentRepository incidentRepository, ICommentRepository commentRepository, IUserRepository userRepository, IMachineRepository machineRepository, IMapper mapper)
        {
            _incidentRepository = incidentRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _machineRepository = machineRepository;
            _mapper = mapper;
        }
        public int Create(int createdBy, int assignedTo, string header, string description, int machineId, out string error)
        {
            try
            {
                var getCreatedBy = _userRepository.FindBy(u => u.Id == createdBy).Result;
                var getAssignedTo = _userRepository.FindBy(u => u.Id == assignedTo).Result;
                var getMachine = _machineRepository.FindBy(m => m.Id == machineId).Result;
                var incident = new Incident
                {
                    AssignedTo = getAssignedTo,
                    CreatedBy = getCreatedBy,
                    Machine = getMachine,
                    Header = header,
                    Description = description,
                    Active = true,
                    Created = DateTime.Now
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
        public CommentModel Comment(int createdBy, int incidentId, string text, out string error)
        {
            try
            {
                var incident = _incidentRepository.FindBy(i => i.Id == incidentId).Result;
                var user = _userRepository.FindBy(i => i.Id == createdBy).Result;
                var comment = new Comment { Incident = incident, Text = text, User = user };
                _commentRepository.Add(comment);
                _commentRepository.SaveChanges();                
                error = "";
                return _mapper.Map<CommentModel>(comment);
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }

        }

        public IncidentModel Get(int incidentId, out string error)
        {
            try
            {
                var incident = _incidentRepository.Includes(incidentId).Result;
                var result = _mapper.Map<IncidentModel>(incident);             
                error = "";
                return result;
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
                var incidents = _incidentRepository.SearchBy(i => i.Active,c => c.CreatedBy, a => a.AssignedTo).Result;
                var result = _mapper.Map<List<IncidentModel>>(incidents);               
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
            
        }
        public List<IncidentModel> GetCreated(int id, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(u => u.Id == id).Result;
                var incidents = _incidentRepository.SearchBy(i => i.CreatedBy == user, c => c.CreatedBy, a => a.AssignedTo).Result;
                var result = _mapper.Map<List<IncidentModel>>(incidents);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }
        public List<IncidentModel> GetAssigned(int id, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(u => u.Id == id).Result;
                var incidents = _incidentRepository.SearchBy(i => i.AssignedTo == user, c => c.CreatedBy, a => a.AssignedTo).Result;
                var result = _mapper.Map<List<IncidentModel>>(incidents);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }
        public bool Update(IncidentModel incident, out string error)
        {
            try
            {
                var currentIncident = _incidentRepository.FindBy(i => i.Id == incident.Id).Result;
                if (incident.Machine != null)
                {
                    var machine = _machineRepository.FindBy(m => m.Id == incident.Machine.Id).Result;
                    currentIncident.Machine = machine;
                }
                if (incident.AssignedTo != null)
                {
                    var assignedTo = _userRepository.FindBy(u => u.Id == incident.AssignedTo.Id).Result;
                    currentIncident.AssignedTo = assignedTo;
                }
                currentIncident.Description = incident.Description;    
                currentIncident.Active = incident.Active;
                var result = _incidentRepository.Update(currentIncident).Result;
                _incidentRepository.SaveChanges();
                error = "";
                return result;
            }
            catch (Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return false;
            }
        }
    }
}
