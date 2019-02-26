﻿using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IIncidentService
    {
        IncidentModel Get(int incidentId, out string error);
        int Create(int createdBy, int assignedTo, string header, string description, int location, out string error);
        List<IncidentModel> GetAll(out string error);
    }
}
