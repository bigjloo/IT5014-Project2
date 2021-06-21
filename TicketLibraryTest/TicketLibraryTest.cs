using Xunit;
using TicketLibrary;
using TicketSystem;

namespace TicketLibraryTest
{
    public class TicketLibraryTest
    {
        // Create Ticket instance with two arguements expect email and creatorname to be not specified
        [Theory]
        [InlineData("JOHND", "Mouse not working")]
        [InlineData("123", "")]
        [InlineData("asdsdsdsdsdsdssdsdssd", "123123123123123123")]
        public void CreateTicket_TwoArgs_NoPasswordChangeRequest_ReturnTicketWithEmailCreatorNameAsNotSpecified(string staffID, string description)
        {
            //Arrange
            string staffId = staffID;
            string desc = description;
            ITicketStats ticketStats = TicketStats.GetInstance();

            //Act
            Ticket ticket = new Ticket(staffId, desc, ticketStats);
            var expected = "Not Specified";

            //Assert
            Assert.IsType<Ticket>(ticket);
            Assert.Equal(ticket.StaffID, staffId);
            Assert.Equal(ticket.Description, desc);
            Assert.Equal(expected, ticket.Email);
            Assert.Equal(expected, ticket.CreatorName);
        }

        // Create Ticket instance with four arguements
        [Fact]
        public void CreateTicket_FourArgs_NoPasswordChangeRequest_ReturnsTicket()
        {
            //Arrange
            string staffID = "JayL";
            string description = "ticket description";
            string email = "jl@gmail.com";
            string creatorName = "Junzhong Loo";
            ITicketStats ticketStats = TicketStats.GetInstance();

            //Act
            Ticket ticket = new Ticket(staffID, description, email, creatorName, ticketStats);

            //Assert
            Assert.IsType<Ticket>(ticket);
            Assert.Equal(ticket.StaffID, staffID);
            Assert.Equal(ticket.Description, description);
            Assert.Equal(ticket.Email, email);
            Assert.Equal(ticket.CreatorName, creatorName);
        }

        // Only one instance of TicketStats 
        [Fact]
        public void TicketStatsReturnsSameInstance()
        {
            var ticketstats1 = TicketStats.GetInstance();
            var ticketstats2 = TicketStats.GetInstance();
            var ticketstats3 = TicketStats.GetInstance();

            Assert.Same(ticketstats1, ticketstats2);
            Assert.Same(ticketstats2, ticketstats3);
        }
        
        // Only one instance of TicketContainer
        [Fact]
        public void TicketContainerReturnsSameInstance()
        {
            var ticketContainer1 = TicketContainer.GetInstance();
            var ticketContainer2 = TicketContainer.GetInstance();
            var ticketContainer3 = TicketContainer.GetInstance();

            Assert.Same(ticketContainer1, ticketContainer2);
            Assert.Same(ticketContainer2, ticketContainer3);
        }

        // Create Ticket with two arguements updates TicketStats created by one and TicketContainer tickets by one 
        [Fact]
        public void CreateTicket_TwoArgs_ReturnsTicket_StatsUpdateByOne_TicketsInContainerUpdateByOne()
        {
            TicketStats ticketStats = TicketStats.GetInstance();
            TicketContainer ticketContainer = TicketContainer.GetInstance();
            
            // Get before Ticket created stats and Ticket count
            var createdBefore = ticketStats.GetCreated();
            var ticketCountBefore = ticketContainer.GetTickets().Count;

            // Create new Ticket
            AppLogic.CreateTicket("test", "test");

            var expectedStats = createdBefore + 1;
            var expectedTicketCount = ticketCountBefore + 1;
            var actualStats = ticketStats.GetCreated();
            var actualTicketCount = ticketContainer.GetTickets().Count;

            Assert.Equal(expectedStats, actualStats);
            Assert.Equal(expectedTicketCount, actualTicketCount);
        }

        // Create Ticket with four arguements updates TicketStats created by one and TicketContainer tickets by one 
        [Fact]
        public void CreateTicket_FourArgs_ReturnsTicket_StatsUpdateByOne_TicketsInContainerUpdateByOne()
        {
            TicketStats ticketStats = TicketStats.GetInstance();
            TicketContainer ticketContainer = TicketContainer.GetInstance();

            var createdBefore = ticketStats.GetCreated();
            var ticketCountBefore = ticketContainer.GetTickets().Count;

            AppLogic.CreateTicket("test", "test", "test", "test");

            var expectedStats = createdBefore + 1;
            var expectedTicketCount = ticketCountBefore + 1;
            var actualStats = ticketStats.GetCreated();
            var actualTicketCount = ticketContainer.GetTickets().Count;

            Assert.Equal(expectedStats, actualStats);
            Assert.Equal(expectedTicketCount, actualTicketCount);
        }

        // Ticket number for Ticket plus one for every new ticket created
        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(9999999)]
        public void CreateTicket_TicketNumberPlusOneForNumberOfTicketsCreated(int numberOfTickets)
        {
            // To get before ticket number
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            var beforeTicketNumber = ticket.TicketNumber;

            // Create numberOfTickets instances of Tickets
            for(var i = 0; i < numberOfTickets; i++)
            {
                AppLogic.CreateTicket("test", "test");
            }
            var tickets = TicketContainer.GetInstance().GetTickets();

            var expected = beforeTicketNumber + numberOfTickets;
            // Get ticket number of last Ticket created
            var actual = tickets[tickets.Count - 1].TicketNumber;

            Assert.Equal(expected, actual);
        }

        // Resolve ticket should:
        // Set status to "Closed"
        // Update TicketStats -> opened -= 1, closed += 1;
        [Fact]
        public void ResolveTicket_ShouldSetStatusToClosed_UpdateStatsOpenedClosed()
        {
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            TicketStats ticketStats = TicketStats.GetInstance();

            var openedStatsBefore = ticketStats.GetOpened();
            var closedStatsBefore = ticketStats.GetClosed();

            var expectedOpenedStatsAfterResolve = openedStatsBefore - 1;
            var expectedClosedStatsAfterResolve = closedStatsBefore + 1;
            var expectedStatusAfter = "Closed";

            ticket.Resolve("test resolve message");

            var actualStatusAfter = ticket.Status;
            var actualStatsClosedAfterResolve = ticketStats.GetClosed();
            var actualStatsOpenedAfterResolve = ticketStats.GetOpened();

            Assert.Equal(expectedStatusAfter, actualStatusAfter);
            Assert.Equal(expectedOpenedStatsAfterResolve, actualStatsOpenedAfterResolve);
            Assert.Equal(expectedClosedStatsAfterResolve, actualStatsClosedAfterResolve);
        }

        // Reopen ticket should:
        // Set status to "Reopened"
        // Update TicketStats -> opened += 1, closed -= 1;
        [Fact]
        public void ReopenTicket_ShouldSetStatusToReopened_UpdateStatsOpenedClosed()
        {
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            TicketStats ticketStats = TicketStats.GetInstance();

            var openedStatsBefore = ticketStats.GetOpened();
            var closedStatsBefore = ticketStats.GetClosed();

            ticket.Reopen();

            var expectedOpenedStatsAfterReopen = openedStatsBefore + 1;
            var expectedClosedStatsAfterReopen = closedStatsBefore - 1;
            var expectedStatusAfter = "Reopened";

            var actualStatusAfter = ticket.Status;
            var actualStatsClosedAfterResolve = ticketStats.GetClosed();
            var actualStatsOpenedAfterResolve = ticketStats.GetOpened();

            Assert.Equal(expectedStatusAfter, actualStatusAfter);
            Assert.Equal(expectedOpenedStatsAfterReopen, actualStatsOpenedAfterResolve);
            Assert.Equal(expectedClosedStatsAfterReopen, actualStatsClosedAfterResolve);
        }

        // Ticket created default Ticket.Response == "Not yet provided"
        // Only when Ticket.Description contains "password change" will default Ticket.Response != "Not yet provided"
        [Theory]
        [InlineData("password change")]
        [InlineData("  password change")]
        [InlineData("password change ")]
        [InlineData("Password Change")]
        public void CreateTicket_WithPasswordChangeInDescription_ReturnsTicketWithPasswordResponse(string description)
        {
            var defaultTicketResponse = "Not Yet Provided";
            Ticket ticket = AppLogic.CreateTicket("test", description);

            var expected = defaultTicketResponse;
            var actual = ticket.Response;
            Assert.NotEqual(expected, actual);
        }

        // path testing. true/false if/else paths
        //      cyclomatic testing
        //      BVA - boundary value analysis - whenever there are limits/bounds

        // control flow/coverage testing
        //  method coverage
        //  statement coverage

        // branch coverage (all true/false statements)
        // password change
        // create ticket constructure args count




        // password change overflow buffer

        // empty string args + password change

        // create 10000000 tickets

    }
}
