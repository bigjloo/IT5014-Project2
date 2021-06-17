using System;
using TicketLibrary;

namespace SystemLogic
{
    public class SystemLogic
    {
        public Ticket CreateTicket(string staffID, string description)
        {
            var ticket = new Ticket(staffID, description);
            TicketStats.UpdateStats(ticket.Status);
            TicketContainer.AddTicket(ticket);

            return ticket;
        }
    }
}
