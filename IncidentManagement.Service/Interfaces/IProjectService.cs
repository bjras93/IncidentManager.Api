using IncidentManagement.Domain;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IProjectService
    {
        Project Get(int projectId, out string error);
        int Create(int createdBy, int assignedTo, string header, string description, out string error);
        List<Project> GetAll(out string error);
        List<Project> GetCreated(int id, out string error);
        List<Project> GetAssigned(int id, out string error);
        Comment Comment(int createdBy, int projectId, string text, out string error);
        bool Update(Project project, out string error);
    }
}
