using System.Threading.Tasks;

namespace Org.Visiontech.Commons
{
    public interface IAuthenticationService
    {
        Task<string> GetTicketGrantingTicket(string username, string password);

        Task<bool> VerifyTicketGrantingTicket(string ticketGrantingTicket);

        Task<string> GetServiceTicket(string ticketGrantingTicket);

    }
}
