using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    // Stores Tickets in a List
    public class TicketContainer
    {
        private static readonly List<Ticket> _tickets = new List<Ticket>();

        public TicketContainer() { }

        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public List<Ticket> GetTickets()
        {
            return _tickets;
        }
    }
}

