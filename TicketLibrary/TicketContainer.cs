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
        private static TicketContainer _instance = new TicketContainer();
        private static readonly List<Ticket> _tickets = new List<Ticket>();

        private TicketContainer() { }
       
        public static TicketContainer GetInstance()
        {
            return _instance;
        }

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

