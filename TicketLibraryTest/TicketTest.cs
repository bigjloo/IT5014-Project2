using Xunit;
using TicketLibrary;
using TicketSystem;

namespace Tests
{
    public class TicketTest
    {
        // Global variables for Tests
        string staffID = "staffID test";
        string description = "description test";
        string email = "email test";
        string creatorName = "creatorName test";
        string defaultResponse = "Not Yet Provided";

        ITicketStats ticketStats = new TicketStats();

        [Fact]
        public void CreateTicket_TwoArgs_ReturnsTicketTypeObject()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            Assert.IsType<Ticket>(ticket);
        }

        [Fact]
        public void CreateTicket_TwoArgs_PropertiesAsArguments()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            var expectedStaffID = staffID;
            var actualStaffID = ticket.StaffID;

            var expectedDescription = description;
            var actualDescription = ticket.Description;

            Assert.Equal(expectedStaffID, actualStaffID);
            Assert.Equal(expectedDescription, actualDescription);
        }

        [Fact]
        public void CreateTicket_TwoArgs_EmailAndCreatorName_NotSpecified()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);
            var expectedEmail = "Not Specified";
            var actualEmail = ticket.Email;

            var expectedCreatorName = "Not Specified";
            var actualCreatorName = ticket.CreatorName;

            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedCreatorName, actualCreatorName);
        }

        [Fact]
        public void CreateTicket_TwoArgs_StatusSetToOpen()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            var expected = "Open";
            var actual = ticket.Status;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateTicket_IncreasesTicketNumberIncreaseByOne()
        {
            // Ticket before
            Ticket ticket = new Ticket(staffID, description, ticketStats);
            // Ticket after
            Ticket ticket2 = new Ticket(staffID, description, ticketStats);

            var beforeTicketNumber = ticket.TicketNumber;
            var afterTicketNumber = ticket2.TicketNumber;

            uint expected = 1;
            uint actual = afterTicketNumber - beforeTicketNumber;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateTicket_TwoArgs_WithPasswordChange_ResponseNotEqualDefault()
        {
            var description = "Password Change";
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            var expectedResponse = defaultResponse;
            var actualResponse = ticket.Response;

            Assert.NotEqual(expectedResponse, actualResponse);
        }

        [Fact]
        public void CreateTicket_TwoArgs_WithPasswordChange_StatusSetToClosed()
        {
            var description = "Password Change";
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            var expected = "Closed";
            var actual = ticket.Status;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateTicket_FourArgs_ReturnsTicketTypeObject()
        {
            Ticket ticket = new Ticket(staffID, description, email, creatorName, ticketStats);

            Assert.IsType<Ticket>(ticket);
        }

        [Fact]
        public void CreateTicket_FourArgs_PropertiesAsArguments()
        {
            Ticket ticket = new Ticket(staffID, description, email, creatorName, ticketStats);

            var expectedStaffID = staffID;
            var actualStaffID = ticket.StaffID;

            var expectedDescription = description;
            var actualDescription = ticket.Description;

            var expectedEmail = email;
            var actualEmail = ticket.Email;

            var expectedCreatorName = creatorName;
            var actualCreatorName = ticket.CreatorName;

            Assert.Equal(expectedStaffID, actualStaffID);
            Assert.Equal(expectedDescription, actualDescription);
            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedCreatorName, actualCreatorName);
        }

        [Fact]
        public void CreateTicket_FourArgs_StatusSetToOpen()
        {
            Ticket ticket = new Ticket(staffID, description, email, creatorName, ticketStats);

            var expected = "Open";
            var actual = ticket.Status;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateTicket_FourArgs_IncreasesTicketNumberIncreaseByOne()
        {
            // Ticket before
            Ticket ticket = new Ticket(staffID, description, ticketStats);
            // Ticket after
            Ticket ticket2 = new Ticket(staffID, description, email, creatorName, ticketStats);

            var beforeTicketNumber = ticket.TicketNumber;
            var afterTicketNumber = ticket2.TicketNumber;

            uint expected = 1;
            uint actual = afterTicketNumber - beforeTicketNumber;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateTicket_FourArgs_WithPasswordChange_ResponseNotEqualDefault()
        {
            var description = "Password Change";
            Ticket ticket = new Ticket(staffID, description, email, description, ticketStats);

            var expectedResponse = defaultResponse;
            var actualResponse = ticket.Response;

            Assert.NotEqual(expectedResponse, actualResponse);
        }

        [Fact]
        public void CreateTicket_FourArgs_WithPasswordChange_StatusSetToClosed()
        {
            var description = "Password Change";
            Ticket ticket = new Ticket(staffID, description, email, creatorName, ticketStats);

            var expected = "Closed";
            var actual = ticket.Status;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Resolve_WithMessage_SetsTicketResponseToMessage()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);
            var message = "test message";

            ticket.Resolve(message);

            var expectedTicketResponse = message;
            var actualTicketResponse = ticket.Response;

            Assert.Equal(expectedTicketResponse, actualTicketResponse);
        }

        [Fact]
        public void Reopen_StatusSetToReopened()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            ticket.Resolve("test");
            ticket.Reopen();

            var expected = "Reopened";
            var actual = ticket.Status;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Resolve_SetsTicketStatusToClosed()
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);
            ticket.Resolve("test");

            var expected = "Closed";
            var actual = ticket.Status;

            Assert.Equal(expected, actual);
        }

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
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            var propertyTicket1 = ticket.GetType().GetProperty(propertyName);

            Assert.NotNull(propertyTicket1);
        }

        [Theory]
        [InlineData("Resolve")]
        [InlineData("Reopen")]
        public void Method_Exist_InTicketClass(string methodName)
        {
            Ticket ticket = new Ticket(staffID, description, ticketStats);

            var methodTicket = ticket.GetType().GetMethod(methodName);

            Assert.NotNull(methodTicket);
        }
    }
}
