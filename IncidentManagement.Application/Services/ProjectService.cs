using AutoMapper;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace IncidentManagement.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, ICommentRepository commentRepository, IUserRepository userRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
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
                var project = new Project
                {
                    AssignedTo = getAssignedTo,
                    CreatedBy = getCreatedBy,
                    Header = header,
                    Description = description,
                    Active = true,
                    Created = DateTime.Now
                };
                _projectRepository.Add(project);
                _projectRepository.SaveChanges();
                error = "";
                return project.Id;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return 0;
            }

        }
        public CommentModel Comment(int createdBy, int projectId, string text, out string error)
        {
            try
            {
                var project = _projectRepository.FindBy(i => i.Id == projectId).Result;
                var user = _userRepository.FindBy(i => i.Id == createdBy).Result;
                var comment = new Comment { Project = project, Text = text, User = user };
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

        public ProjectModel Get(int projectId, out string error)
        {
            try
            {
                var project = _projectRepository.FindBy(x => x.Id == projectId).Result;
                var result = _mapper.Map<ProjectModel>(project);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }

        public List<ProjectModel> GetAll(out string error)
        {
            try
            {
                var projects = _projectRepository.SearchBy(i => i.Active, c => c.CreatedBy, a => a.AssignedTo).Result;
                var result = _mapper.Map<List<ProjectModel>>(projects);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }

        }
        public List<ProjectModel> GetCreated(int id, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(u => u.Id == id).Result;
                var projects = _projectRepository.SearchBy(i => i.CreatedBy == user, c => c.CreatedBy, a => a.AssignedTo).Result;
                var result = _mapper.Map<List<ProjectModel>>(projects);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }
        public List<ProjectModel> GetAssigned(int id, out string error)
        {
            try
            {
                var user = _userRepository.FindBy(u => u.Id == id).Result;
                var projects = _projectRepository.SearchBy(i => i.AssignedTo == user, c => c.CreatedBy, a => a.AssignedTo).Result;
                var result = _mapper.Map<List<ProjectModel>>(projects);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }
        public bool Update(ProjectModel project, out string error)
        {
            try
            {
                var currentProject = _projectRepository.FindBy(i => i.Id == project.Id).Result;              
                if (project.AssignedTo != null)
                {
                    var assignedTo = _userRepository.FindBy(u => u.Id == project.AssignedTo.Id).Result;
                    currentProject.AssignedTo = assignedTo;
                }
                currentProject.Description = project.Description;
                currentProject.Active = project.Active;
                var result = _projectRepository.Update(currentProject).Result;
                _projectRepository.SaveChanges();
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
