using Xunit;
using TicketLibrary;
using TicketSystem;

namespace Tests
{
    public class TicketFactoryTest
    {
        TicketStats ticketStats = new TicketStats();
        TicketContainer ticketContainer = new TicketContainer();
        
        [Fact]
        public void CreateTicketFactory_ReturnsTicketFactoryTypeObject()
        {
            var ticketFactory = new TicketFactory(ticketStats, ticketContainer);

            Assert.IsType<TicketFactory>(ticketFactory);
        }

        [Fact]
        public void CreateTicketFromFactory_TwoArgs_ReturnsTicket()
        {
            TicketFactory ticketFactory = new TicketFactory(ticketStats, ticketContainer);
            var ticket = ticketFactory.CreateTicket("test", "test");

            Assert.IsType<Ticket>(ticket);
        }

        [Fact]
        public void CreateTicketFromFactory_TwoArgs_IncreaseTicketsCountByOne()
        {
            var ticketsCountBefore = ticketContainer.GetTickets().Count;

            TicketFactory ticketFactory = new TicketFactory(ticketStats, ticketContainer);
            var ticket = ticketFactory.CreateTicket("test", "test");

            var expected = ticketsCountBefore + 1;
            var actual = ticketContainer.GetTickets().Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateTicketFromFactory_FourArgs_ReturnsTicket()
        {
            TicketFactory ticketFactory = new TicketFactory(ticketStats, ticketContainer);
            var ticket = ticketFactory.CreateTicket("test", "test", "test", "test");

            Assert.IsType<Ticket>(ticket);
        }

        [Fact]
        public void CreateTicketFromFactory_FourArgs_IncreaseTicketsCountByOne()
        {
            var ticketsCountBefore = ticketContainer.GetTickets().Count;

            TicketFactory ticketFactory = new TicketFactory(ticketStats, ticketContainer);
            var ticket = ticketFactory.CreateTicket("test", "test", "test", "test");

            var expected = ticketsCountBefore + 1;
            var actual = ticketContainer.GetTickets().Count;

            Assert.Equal(expected, actual);
        }
    }
}
