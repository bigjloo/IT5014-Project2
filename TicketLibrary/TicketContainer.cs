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
        // Using a List to store tickets
        readonly List<ITicket> _tickets;
        
        public TicketContainer()
        {
            _tickets = new List<ITicket>();
        }

        // Adds ticket to _tickets list
        public void AddTicket(ITicket ticket)
        {
            _tickets.Add(ticket);
        }

        // Returns a list of tickets
        public List<ITicket> GetTickets()
        {
            return _tickets;
        }
    }
}

