using System;
using TicketLibrary;

namespace TicketSystem
{
    public class TicketFactory
    {
        readonly ITicketStats _ticketStats;
        readonly ITicketContainer _ticketContainer;

        public TicketFactory(ITicketStats ticketStats, ITicketContainer ticketContainer)
        {
            _ticketStats = ticketStats;
            _ticketContainer = ticketContainer;
        }
        public ITicket CreateTicket(string staffID, string description)
        {

            ITicket ticket = new Ticket(staffID, description, _ticketStats);
            _ticketContainer.AddTicket(ticket);

            return ticket;
        }

        public ITicket CreateTicket(string staffID, string description, string email, string creatorName)
        {
            ITicket ticket = new Ticket(staffID, description, email, creatorName, _ticketStats);
            _ticketContainer.AddTicket(ticket);

            return ticket;
        }
    }
}
