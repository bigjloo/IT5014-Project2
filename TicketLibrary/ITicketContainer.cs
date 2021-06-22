using System.Collections.Generic;

namespace TicketLibrary
{
    public interface ITicketContainer
    {
        void AddTicket(ITicket ticket);
        List<ITicket> GetTickets();
    }
}