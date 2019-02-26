using IncidentManagement.Repository.DTO;
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
        public Task<Machine> Includes(int id)
        {
            return Task.FromResult(_repositoryContext.Machines.Include(u => u.Location).Include(i => i.Incidents).FirstOrDefault(i => i.Id == id));
        }
        public Task<List<Machine>> IncludesLocation()
        {
            return Task.FromResult(_repositoryContext.Machines.Include(u => u.Location).ToList());
        }
    }
}
