using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IIncidentService
    {
        IncidentModel Get(int incidentId, out string error);
        int Create(int createdBy, int assignedTo, string header, string description, int machineId, out string error);
        List<IncidentModel> GetAll(out string error);
        List<IncidentModel> GetCreated(int id, out string error);
        List<IncidentModel> GetAssigned(int id, out string error);
        CommentModel Comment(int createdBy, int incidentId, string text, out string error);
        bool Update(IncidentModel incident, out string error);
    }
}
