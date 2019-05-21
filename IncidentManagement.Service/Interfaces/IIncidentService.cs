using IncidentManagement.Domain;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IIncidentService
    {
        Incident Get(int incidentId, out string error);
        int Create(int createdBy, int assignedTo, string header, string description, int machineId, out string error);
        List<Incident> GetAll(out string error);
        List<Incident> GetCreated(int id, out string error);
        List<Incident> GetAssigned(int id, out string error);
        Comment Comment(int createdBy, int incidentId, string text, out string error);
        bool Update(Incident incident, out string error);
    }
}
