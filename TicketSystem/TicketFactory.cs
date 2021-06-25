using System;
using TicketLibrary;

namespace TicketSystem
{
    public class TicketFactory
    {
        readonly ITicketStats _ticketStats;
        readonly ITicketContainer _ticketContainer;

        // _ticketStats and _ticketContainer set in constructor when TicketFactory is created
        // To be used for creating Ticket 
        public TicketFactory(ITicketStats ticketStats, ITicketContainer ticketContainer)
        {
            _ticketStats = ticketStats;
            _ticketContainer = ticketContainer;
        }

        // Two arguments provided from user
        public ITicket CreateTicket(string staffID, string description)
        {
            ITicket ticket = new Ticket(staffID, description, _ticketStats);
            _ticketContainer.AddTicket(ticket);

            return ticket;
        }

        // Four arguments provided from user
        public ITicket CreateTicket(string staffID, string description, string email, string creatorName)
        {
            ITicket ticket = new Ticket(staffID, description, email, creatorName, _ticketStats);
            _ticketContainer.AddTicket(ticket);

            return ticket;
        }
    }
}
