using System;
using TicketLibrary;

namespace TicketSystem
{
    public static class Factory
    {
        public static ITicket CreateTicket(string staffID, string description, ITicketStats ticketStats, ITicketContainer ticketContainer)
        {

            ITicket ticket = new Ticket(staffID, description, ticketStats);
            ticketContainer.AddTicket(ticket);

            return ticket;
        }

        public static ITicket CreateTicket(string staffID, string description, string creatorName, string email, ITicketStats ticketStats, ITicketContainer ticketContainer)
        {
            ITicket ticket = new Ticket(staffID, description, creatorName, email, ticketStats);
            ticketContainer.AddTicket(ticket);

            return ticket;
        }

        public static ITicketStats CreateTicketStats()
        {
            return new TicketStats();
        }

        public static ITicketContainer CreateTicketContainer()
        {
            return new TicketContainer();
        }

        
    }
}
