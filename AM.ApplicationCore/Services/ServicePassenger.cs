

using AM.ApplicationCore.Services;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Interfaces
{
    public class ServicePassenger : Service<Passenger>, IServicePassenger
    {
        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
