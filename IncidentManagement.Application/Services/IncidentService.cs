﻿using System.Collections.Generic;
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
        private readonly IMapper _mapper;
        public IncidentService(IIncidentRepository incidentRepository, ICommentRepository commentRepository, IUserRepository userRepository, IMapper mapper)
        {
            _incidentRepository = incidentRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public int Create(int createdBy, int assignedTo, string header, string description, out string error)
        {
            try
            {
                var getCreatedBy = _userRepository.FindBy(u => u.Id == createdBy).Result;
                var getAssignedTo = _userRepository.FindBy(u => u.Id == assignedTo).Result;
                var incident = new Incident
                {
                    AssignedTo = getAssignedTo,
                    CreatedBy = getCreatedBy,
                    Header = header,
                    Description = description
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
                var incidents = _incidentRepository.GetAll().Result;
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
    }
}