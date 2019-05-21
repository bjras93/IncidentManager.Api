using System.Collections.Generic;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Domain;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public Location Get(int locationId, out string error)
        {
            try
            {
                var location = _locationRepository.FindBy(l => l.Id == locationId).Result;
                error = "";
                var Location = new Location { Name = location.Name };
                return Location;
            }
            catch (System.Exception e)
            {
                error = e.InnerException.ToString();
                return null;
            }            
        }
        public int Create(string description, string name, out string error)
        {
            try
            {
                var location = new Location
                {
                    Name = name
                };
                _locationRepository.Add(location);
                _locationRepository.SaveChanges();
                error = "";
                return location.Id;
                
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return 0;
            }
        }

        public List<Location> GetAll(out string error)
        {
            try
            {
                var locations = _locationRepository.GetAll().Result;
                var locationsModel = new List<Location>();
                foreach(var location in locations)
                {
                    locationsModel.Add(new Location
                    {
                        Id = location.Id,
                        Name = location.Name
                    });
                }
                error = "";
                return locationsModel;
            }
            catch (System.Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return null;
            }
        }
    }
}
