using System.Collections.Generic;
using AutoMapper;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Application.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IIncidentRepository _incidentRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public MachineService(IMachineRepository machineRepository, IIncidentRepository incidentRepository, ICommentRepository commentRepository, IUserRepository userRepository, ILocationRepository locationRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _incidentRepository = incidentRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public int Create(string name, string locationName, out string error)
        {
            try
            {
                var getLocation = _locationRepository.FindBy(l => l.Name == locationName).Result;
                if (getLocation == null)
                {
                    getLocation = new Location { Name = locationName };
                    _locationRepository.Add(getLocation);
                    _locationRepository.SaveChanges();
                }
                var machine = new Machine
                {
                    Name = name,
                    Location = getLocation,
                };
                _machineRepository.Add(machine);
                _machineRepository.SaveChanges();
                error = "";
                return machine.Id;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return 0;
            }

        }

        public MachineModel Get(int machineId, out string error)
        {
            try
            {
                var machine = _machineRepository.Includes(machineId).Result;
                var result = _mapper.Map<MachineModel>(machine);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }

        public List<MachineModel> GetAll(out string error)
        {
            try
            {
                var machines = _machineRepository.IncludesLocation().Result;
                var result = _mapper.Map<List<MachineModel>>(machines);               
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
