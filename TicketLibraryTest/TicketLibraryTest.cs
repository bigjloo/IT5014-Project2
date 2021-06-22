using Xunit;
using TicketLibrary;
using TicketSystem;

namespace Tests
{
    public class TicketLibraryTest
    {
        // Global variables for Tests
        TicketContainer ticketContainer = new TicketContainer();
        TicketStats ticketStats = new TicketStats();

        //string defaultResponse = "Not Yet Provided";
        //string defaultEmpty = "Not Specified";

        //string staffID = "staffID test";
        //string description = "description test";
        //string email = "email test";
        //string creatorName = "creatorName test";

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
            ITicket ticket = Factory.CreateTicket(staffID, description, ticketStats, ticketContainer);

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

            ITicket ticket = Factory.CreateTicket(staffID, description, ticketStats, ticketContainer);

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

            ITicket ticket = Factory.CreateTicket(staffID, description, email, creatorName, ticketStats, ticketContainer);

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

            ITicket ticket = Factory.CreateTicket(staffID, description, email, creatorName, ticketStats, ticketContainer);

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



        // Test #6
        // w



        // Test #8
        // Ticket counter static field + 1 for every ticket created
        [Fact]
        public void CreateTicket_TicketNumberPlusOne()
        {
            // Ticket before
            ITicket ticket = Factory.CreateTicket("test", "test", ticketStats, ticketContainer);
            // Ticket after
            ITicket ticket2 = Factory.CreateTicket("test", "test", "test", "test", ticketStats, ticketContainer);
            
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
            ITicket ticket = Factory.CreateTicket("test", "test", ticketStats, ticketContainer);
            ITicket ticket2 = Factory.CreateTicket("test", "test", "test", "test", ticketStats, ticketContainer);
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
            ITicket ticket = Factory.CreateTicket("test", "test", ticketStats, ticketContainer);
            ITicket ticket2 = Factory.CreateTicket("test", "test", "test", "test", ticketStats, ticketContainer);

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
            ITicket ticket = Factory.CreateTicket("test", "test", ticketStats, ticketContainer);
            ITicket ticket2 = Factory.CreateTicket("test", "test", "test", "test", ticketStats, ticketContainer);

            var methodTicket1 = ticket.GetType().GetMethod(methodName);
            var methodTicket2 = ticket2.GetType().GetMethod(methodName);

            Assert.NotNull(methodTicket1);
            Assert.NotNull(methodTicket2);
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
