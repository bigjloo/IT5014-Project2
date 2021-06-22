using Xunit;
using TicketLibrary;
using TicketSystem;

namespace Tests
{
    public class TicketContainerTest
    {
        // Test #
        [Fact]
        public void AddTicket_TicketListCountPlusOne()
        {
            ITicketContainer ticketContainer = Factory.CreateTicketContainer();
            ITicketStats ticketStats = Factory.CreateTicketStats();
            ITicket ticket = new Ticket("test", "test", ticketStats);

            var beforeTicketsCount = ticketContainer.GetTickets().Count;

            ticketContainer.AddTicket(ticket);

            var afterTicketsCount = ticketContainer.GetTickets().Count;

            var expected = 1;
            var actual = afterTicketsCount - beforeTicketsCount;

            Assert.Equal(expected, actual);
        }

        // Test #
        [Fact]
        public void AddTicket_TicketExistsInTicketContainer()
        {
            ITicketContainer ticketContainer = Factory.CreateTicketContainer();
            ITicketStats ticketStats = Factory.CreateTicketStats();
            ITicket ticket = new Ticket("test2", "test2", ticketStats);

            ticketContainer.AddTicket(ticket);
            var tickets = ticketContainer.GetTickets();

            var expected = true;
            var actual = tickets.Contains(ticket);

            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void GetTickets_ReturnListOfTickets()
        //{
        //    ITicketContainer ticketContainer = AppLogic.CreateTicketContainer();
        //    ITicketStats ticketStats = AppLogic.CreateTicketStats();

        //    ITicket ticket = new Ticket("test", "test", ticketStats);
        //    ITicket ticket2 = new Ticket("test2", "test2", ticketStats);

        //    ticketContainer.AddTicket(ticket);
        //    ticketContainer.AddTicket(ticket2);

        //    var tickets = ticketContainer.GetTickets();
        //    var expected = 
        //    var actual = tickets.GetType();
        //    Assert.Equal(actual)

        //}
    }
}
