using Xunit;
using TicketLibrary;
using TicketSystem;

namespace Tests
{
    public class TicketContainerTest
    {
        TicketStats ticketStats = new TicketStats();
        TicketContainer ticketContainer = new TicketContainer();

        // Test #
        [Fact]
        public void AddTicket_TicketListCountPlusOne()
        {
            Ticket ticket = new Ticket("test", "test", ticketStats);
            var beforeTicketsCount = ticketContainer.GetTickets().Count;

            ticketContainer.AddTicket(ticket);

            var expected = beforeTicketsCount + 1;
            var actual = ticketContainer.GetTickets().Count;

            Assert.Equal(expected, actual);
        }

        // Test #
        [Fact]
        public void AddTicket_TicketExistsInTicketContainer()
        {
            Ticket ticket = new Ticket("test2", "test2", ticketStats);

            ticketContainer.AddTicket(ticket);
            var tickets = ticketContainer.GetTickets();

            var expected = true;
            var actual = tickets.Contains(ticket);

            Assert.Equal(expected, actual);
        }
    }
}
