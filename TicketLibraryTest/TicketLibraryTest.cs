using Xunit;
using TicketLibrary;
using TicketSystem;

namespace TicketLibraryTest
{
    public class TicketLibraryTest
    {

        // Test #1
        // Creates Ticket with two arguments, password change
        // Expect:
        //   Ticket of type Ticket
        //   Ticket.Email, Ticket.CreatorName == "Not Specified"
        //   Ticket.Response != "Not Yet Provided"
        [Fact]
        public void CreateTicket_TwoArgs_WithPasswordChangeInDescription()
        {
            var staffID = "staffID test";
            var description = "Password Change";
            Ticket ticket = AppLogic.CreateTicket(staffID, description);

            var expectedResponse = "Not Yet Provided";
            var actualResponse = ticket.Response;

            var expectedStaffID = staffID;
            var actualStaffID = ticket.StaffID;

            var expectedDescription = description;
            var actualDescription = ticket.Description;

            var expectedEmail = "Not Specified";
            var actualEmail = ticket.Email;

            var expectedCreatorName = "Not Specified";
            var actualCreatorName = ticket.CreatorName;

            Assert.IsType<Ticket>(ticket);
            Assert.NotEqual(expectedResponse, actualResponse);
            Assert.Equal(expectedStaffID, actualStaffID);
            Assert.Equal(expectedDescription, actualDescription);
            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedCreatorName, actualCreatorName);
        }

        // Test #2
        // Create Ticket instance with two arguements, no password change
        // Expect:
        //   Ticket of type Ticket
        //   Ticket.Email and Ticket.CreatorName == "Not Specified"
        //   Ticket.Response == "Not Yet Provided"
        [Theory]
        [InlineData("JOHND", "Mouse not working")]
        [InlineData("123", "")]
        [InlineData("asdsdsdsdsdsdssdsdssd", "123123123123123123")]
        public void CreateTicket_TwoArgs_NoPasswordChangeRequest(string staffID, string description)
        {
            //Arrange
            string staffId = staffID;
            string desc = description;

            Ticket ticket = AppLogic.CreateTicket(staffID, description);

            var expectedResponse = "Not Yet Provided";
            var actualResponse = ticket.Response;

            var expectedStaffID = staffID;
            var actualStaffID = ticket.StaffID;

            var expectedDescription = description;
            var actualDescription = ticket.Description;

            var expectedEmail = "Not Specified";
            var actualEmail = ticket.Email;

            var expectedCreatorName = "Not Specified";
            var actualCreatorName = ticket.CreatorName;

            Assert.IsType<Ticket>(ticket);
            Assert.Equal(expectedResponse, actualResponse);
            Assert.Equal(expectedStaffID, actualStaffID);
            Assert.Equal(expectedDescription, actualDescription);
            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedCreatorName, actualCreatorName);
        }

        // Test #3
        // Create Ticket instance with four arguments, password change
        // Expect:
        //   Ticket of type Ticket
        //   Ticket.Response != "Not Yet Provided"
        [Fact]
        public void CreateTicket_FourArgs_WithPasswordChangeInDescription()
        {
            var staffID = "staffID test";
            var description = "Password Change";
            var email = "email test";
            var creatorName = "creatorName test";

            Ticket ticket = AppLogic.CreateTicket(staffID, description, email, creatorName);

            var expectedResponse = "Not Yet Provided";
            var actualResponse = ticket.Response;

            var expectedStaffID = staffID;
            var actualStaffID = ticket.StaffID;

            var expectedDescription = description;
            var actualDescription = ticket.Description;

            var expectedEmail = email;
            var actualEmail = ticket.Email;

            var expectedCreatorName = creatorName;
            var actualCreatorName = ticket.CreatorName;

            Assert.IsType<Ticket>(ticket);
            Assert.NotEqual(expectedResponse, actualResponse);
            Assert.Equal(expectedStaffID, actualStaffID);
            Assert.Equal(expectedDescription, actualDescription);
            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedCreatorName, actualCreatorName);
        }

        // Test #4
        // Create Ticket instance with four arguements, no password change
        // Expect:
        //   Ticket of type Ticket
        //   Ticket.Response == "Not Yet Provided"
        [Fact]
        public void CreateTicket_FourArgs_NoPasswordChangeRequest()
        {
            var staffID = "staffID test";
            var description = "description test";
            var email = "email test";
            var creatorName = "creatorName test";

            Ticket ticket = AppLogic.CreateTicket(staffID, description, email, creatorName);

            var expectedResponse = "Not Yet Provided";
            var actualResponse = ticket.Response;

            var expectedStaffID = staffID;
            var actualStaffID = ticket.StaffID;

            var expectedDescription = description;
            var actualDescription = ticket.Description;

            var expectedEmail = email;
            var actualEmail = ticket.Email;

            var expectedCreatorName = creatorName;
            var actualCreatorName = ticket.CreatorName;

            Assert.IsType<Ticket>(ticket);
            Assert.Equal(expectedResponse, actualResponse);
            Assert.Equal(expectedStaffID, actualStaffID);
            Assert.Equal(expectedDescription, actualDescription);
            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedCreatorName, actualCreatorName);
        }

        // Test #5
        // Only one instance of TicketStats 
        [Fact]
        public void TicketStatsReturnsSameInstance()
        {
            var ticketstats1 = TicketStats.GetInstance();
            var ticketstats2 = TicketStats.GetInstance();
            var ticketstats3 = TicketStats.GetInstance();

            Assert.True(ticketstats1.Equals(ticketstats2));
            Assert.True(ticketstats2.Equals(ticketstats3));
        }
        
        // Test #6
        // Only one instance of TicketContainer
        [Fact]
        public void TicketContainerReturnsSameInstance()
        {
            var ticketContainer1 = TicketContainer.GetInstance();
            var ticketContainer2 = TicketContainer.GetInstance();
            var ticketContainer3 = TicketContainer.GetInstance();

            Assert.True(ticketContainer1.Equals(ticketContainer2));
            Assert.True(ticketContainer2.Equals(ticketContainer3));
        }

        // Test #7
        // For every Ticket created:
        //   TicketStats.Created += 1
        //   TicketStats.Opened += 1
        [Fact]
        public void CreateTicket_StatsUpdateByOnePerTicket()
        {
            TicketStats ticketStats = TicketStats.GetInstance();

            // Get before Ticket created stats and Ticket count
            var createdBefore = ticketStats.GetCreated();
            var openedBefore = ticketStats.GetOpened();

            // Create Tickets 
            AppLogic.CreateTicket("test", "test");
            AppLogic.CreateTicket("test", "test", "test", "test");

            var expectedCreatedAfter = createdBefore + 2;
            var actualCreatedAfter = ticketStats.GetCreated();

            var expectedOpenedAfter = openedBefore + 2;
            var actualOpenedAfter = ticketStats.GetOpened();

            Assert.Equal(expectedCreatedAfter, actualCreatedAfter);
            Assert.Equal(expectedOpenedAfter, actualOpenedAfter);
        }

        // Test #8
        // Ticket counter static field + 1 for every ticket created
        [Fact]
        public void CreateTicket_TicketNumberPlusOne()
        {
            // To get before ticket number
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            Ticket ticket2 = AppLogic.CreateTicket("test", "test", "test", "test");
            
            var beforeTicketNumber = ticket.TicketNumber;
            var afterTicketNumber = ticket2.TicketNumber;

            uint expected = 1;
            var actual = afterTicketNumber - beforeTicketNumber;

            Assert.Equal(expected, actual);
        }

        // Test #9
        // Method: Ticket.Resolve(message) sets Ticket.Response == message
        [Fact]
        public void Resolve_WithMessage_SetsTicketResponseToMessage()
        {
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            Ticket ticket2 = AppLogic.CreateTicket("test", "test", "test", "test");
            var message = "test message";

            ticket.Resolve(message);
            ticket2.Resolve(message);

            var expectedTicket1Response = message;
            var actualTicket1Response = ticket.Response;

            var expectedTicket2Response = message;
            var actualTicket2Response = ticket2.Response;

            Assert.Equal(expectedTicket1Response, actualTicket1Response);
            Assert.Equal(expectedTicket2Response, actualTicket2Response);
        }

        // Test #10
        // Method: Ticket.Resolve() updates TicketStats.Opened -1 and TicketStats.Closed +1
        [Fact]
        public void Resolve_Updates_TicketStatsOpenedMinusOne_TicketStatsClosedPlusOne()
        {
            TicketStats ticketStats = TicketStats.GetInstance();
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            Ticket ticket2 = AppLogic.CreateTicket("test", "test", "test", "test");
            
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
            TicketStats ticketStats = TicketStats.GetInstance();
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            Ticket ticket2 = AppLogic.CreateTicket("test", "test", "test", "test");
            ticket.Resolve("");
            ticket2.Resolve("");

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

        // Test #12
        // Property: Ticket should have properties of:
        [Theory]
        [InlineData("TicketNumber")]
        [InlineData("CreatorName")]
        [InlineData("StaffID")]
        [InlineData("Email")]
        [InlineData("Description")]
        [InlineData("Response")]
        [InlineData("Status")]
        public void Property_Exist_InTicketClass(string propertyName)
        {
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            Ticket ticket2 = AppLogic.CreateTicket("test", "test", "test", "test");

            var propertyTicket1 = ticket.GetType().GetProperty(propertyName);
            var propertyTicket2 = ticket2.GetType().GetProperty(propertyName);

            Assert.NotNull(propertyTicket1);
            Assert.NotNull(propertyTicket2);
        }

        // Test #13
        // Method: Ticket should have method for:
        [Theory]
        [InlineData("Resolve")]
        [InlineData("Reopen")]
        public void Method_Exist_InTicketClass(string methodName)
        {
            Ticket ticket = AppLogic.CreateTicket("test", "test");
            Ticket ticket2 = AppLogic.CreateTicket("test", "test", "test", "test");

            var methodTicket1 = ticket.GetType().GetMethod(methodName);
            var methodTicket2 = ticket2.GetType().GetMethod(methodName);

            Assert.NotNull(methodTicket1);
            Assert.NotNull(methodTicket2);
        }

        // Test #14
        // Method: TicketStats.GetTicketStats exists and return type <string>
        [Fact]
        public void Method_Exist_GetTicketStats_ReturnTypeIsString()
        {
            TicketStats ticketStats = TicketStats.GetInstance();
            var ticketStatsString = ticketStats.GetTicketStats();

            Assert.IsType<string>(ticketStatsString);
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
