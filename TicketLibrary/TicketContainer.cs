using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    // Stores Tickets in a List
    public class TicketContainer : ITicketContainer
    {
        readonly List<ITicket> _tickets;
        public TicketContainer() => _tickets = new List<ITicket>();

        public void AddTicket(ITicket ticket) => _tickets.Add(ticket);

        public List<ITicket> GetTickets() => _tickets;
    }
}

