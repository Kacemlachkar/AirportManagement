using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Domain;
using System.Collections.Generic;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {           
            int capacity = Get(p=>p.Flights.Contains(flight)==true).Capacity;
            int nbPassengers =flight.Tickets.Count();
            //return ;
            return capacity>=(nbPassengers+n);
        }

        public void DeletePlanes()
        {
            foreach (var plane in GetMany().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 365 * 10).ToList())
            {
                Delete(plane);
                Commit();
            }
        }

        public IList<IGrouping<int,Flight>> GetFlights(int n)
        {
           return GetMany().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).GroupBy(f=>f.Plane.PlaneId).ToList();
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return GetById(plane.PlaneId).Flights.SelectMany(f=>f.Tickets.Select(t=>t.Passenger)).ToList();
        }
    }
}
