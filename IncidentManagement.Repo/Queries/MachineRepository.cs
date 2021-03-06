﻿using IncidentManagement.Domain;
using IncidentManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.Queries
{
    public class MachineRepository : BaseRepository<Machine>, IMachineRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public MachineRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;            
        }
        /// <summary>
        /// Includes:
        /// Location
        /// Incidents
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Machine</returns>
        public Task<Machine> WithIncidents(int id)
        {
            return Task.FromResult(_repositoryContext.Machines.Include(u => u.Location)
                .Include(i => i.Incidents)
                .ThenInclude(i => i.CreatedBy)
                .Include(i => i.Incidents)
                .ThenInclude(i => i.AssignedTo)
                .FirstOrDefault(i => i.Id == id));
        }
    }
}
