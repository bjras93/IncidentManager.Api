using IncidentManagement.Application.Models;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IProjectService
    {
        ProjectModel Get(int projectId, out string error);
        int Create(int createdBy, int assignedTo, string header, string description, out string error);
        List<ProjectModel> GetAll(out string error);
        List<ProjectModel> GetCreated(int id, out string error);
        List<ProjectModel> GetAssigned(int id, out string error);
        CommentModel Comment(int createdBy, int projectId, string text, out string error);
        bool Update(ProjectModel project, out string error);
    }
}
