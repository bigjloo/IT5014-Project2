using Xunit;
using TicketLibrary;
using TicketSystem;

namespace Tests
{
    public class TIcketStatsTest
    {
        ITicketContainer ticketContainer = Factory.CreateTicketContainer();
        // Test #5
        // TicketStats variables encapsulated with default value of 0
        [Fact]
        public void TicketStats_VariablesEncapsulatedWithDefaultZero()
        {
            TicketStats ticketStats = new TicketStats();
            var openDefault = ticketStats.GetOpened();
            var closedDefault = ticketStats.GetClosed();
            var createdDefault = ticketStats.GetCreated();

            uint expectedOpen = 0;
            uint expectedClosed = 0;
            uint expectedCreated = 0;

            Assert.Equal(expectedOpen, openDefault);
            Assert.Equal(expectedClosed, closedDefault);
            Assert.Equal(expectedCreated, createdDefault);
        }

        // Test #7
        // For every Ticket created:
        //   TicketStats.Created += 1
        //   TicketStats.Opened += 1
        [Fact]
        public void CreateTicket_StatsUpdateByOnePerTicket()
        {
            TicketStats ticketStats = new TicketStats();

            // Get before Ticket created stats and Ticket count
            var createdBefore = ticketStats.GetCreated();
            var openedBefore = ticketStats.GetOpened();

            // Create Tickets 
            Factory.CreateTicket("test", "test", ticketStats, ticketContainer);
            Factory.CreateTicket("test", "test", "test", "test", ticketStats, ticketContainer);

            var expectedCreatedAfter = createdBefore + 2;
            var actualCreatedAfter = ticketStats.GetCreated();

            var expectedOpenedAfter = openedBefore + 2;
            var actualOpenedAfter = ticketStats.GetOpened();

            Assert.Equal(expectedCreatedAfter, actualCreatedAfter);
            Assert.Equal(expectedOpenedAfter, actualOpenedAfter);
        }

        // Test #10
        // Method: Ticket.Resolve() updates TicketStats.Opened -1 and TicketStats.Closed +1
        [Fact]
        public void Resolve_Updates_TicketStatsOpenedMinusOne_TicketStatsClosedPlusOne()
        {
            TicketStats ticketStats = new TicketStats();
            ITicket ticket = Factory.CreateTicket("test", "test", ticketStats, ticketContainer);
            ITicket ticket2 = Factory.CreateTicket("test", "test", "test", "test", ticketStats, ticketContainer);

            var beforeOpened = ticketStats.GetOpened();
            var beforeClosed = ticketStats.GetClosed();

            ticket.Resolve("test");
            ticket2.Resolve("test");

            var expectedAfterOpened = beforeOpened - 2;
            var actualAfterOpened = ticketStats.GetOpened();

            var expectedAfterClosed = beforeClosed + 2;
            var actualAfterClosed = ticketStats.GetClosed();

            Assert.Equal(expectedAfterOpened, actualAfterOpened);
            Assert.Equal(expectedAfterClosed, actualAfterClosed);
        }

        // Test #11
        // Method: Ticket.Reopen() updates TicketStats.Opened +1 and TicketStats.Closed -1
        [Fact]
        public void Reopen_Updates_TicketStatsOpenedPlusOne_TicketStatsClosedMinusOne()
        {
            TicketStats ticketStats = new TicketStats();
            ITicket ticket = Factory.CreateTicket("test", "test", ticketStats, ticketContainer);
            ITicket ticket2 = Factory.CreateTicket("test", "test", "test", "test", ticketStats, ticketContainer);
            ticket.Resolve("test");
            ticket2.Resolve("test");

            var beforeOpened = ticketStats.GetOpened();
            var beforeClosed = ticketStats.GetClosed();

            ticket.Reopen();
            ticket2.Reopen();

            var expectedAfterOpened = beforeOpened + 2;
            var actualAfterOpened = ticketStats.GetOpened();

            var expectedAfterClosed = beforeClosed - 2;
            var actualAfterClosed = ticketStats.GetClosed();

            Assert.Equal(expectedAfterOpened, actualAfterOpened);
            Assert.Equal(expectedAfterClosed, actualAfterClosed);
        }

        // Test #14
        // Method: TicketStats.GetTicketStats exists and return type <string>
        [Fact]
        public void Method_Exist_GetTicketStats_ReturnTypeIsString()
        {
            TicketStats ticketStats = new TicketStats();
            var ticketStatsString = ticketStats.GetTicketStats();

            Assert.IsType<string>(ticketStatsString);
        }
    }
}
