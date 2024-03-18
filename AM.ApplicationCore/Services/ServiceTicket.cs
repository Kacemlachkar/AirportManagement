using AM.ApplicationCore.Services;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Domain;
using System.Text.RegularExpressions;

namespace AM.ApplicationCore.Interfaces
{
    public class ServiceTicket : Service<Ticket>, IServiceTicket
    {
        public ServiceTicket(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}
