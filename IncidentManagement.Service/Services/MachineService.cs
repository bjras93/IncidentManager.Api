﻿using System.Collections.Generic;
using AutoMapper;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Domain;
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

        public Machine Get(int machineId, out string error)
        {
            try
            {
                var machine = _machineRepository.WithIncidents(machineId).Result;
                var result = _mapper.Map<Machine>(machine);
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }

        public List<Machine> GetAll(out string error)
        {
            try
            {
                var machines = _machineRepository.GetAll(l => l.Location).Result;
                var result = _mapper.Map<List<Machine>>(machines);                      
                error = "";
                return result;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
            
        }
        public bool Update(Machine machine, out string error)
        {
            try
            {
                var currentMachine = _machineRepository.FindBy(m => m.Id == machine.Id, m => m.Incidents, m => m.Location).Result;
                currentMachine.Name = machine.Name;
                if(machine.Location.Id == 0)
                {
                    var newLocation = new Location
                    {
                        Name = machine.Location.Name
                    };
                    _locationRepository.Add(newLocation);
                    _locationRepository.SaveChanges();
                    currentMachine.Location = newLocation;
                }
                else
                {
                    var currentLocation = _locationRepository.FindBy(l => l.Id == machine.Location.Id).Result;
                    currentLocation.Name = machine.Location.Name;
                    currentMachine.Location = currentLocation;
                }
                var updated = _machineRepository.Update(currentMachine).Result;
                _machineRepository.SaveChanges();
                error = "";
                return updated;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return false;
            }
        }
    }
}
