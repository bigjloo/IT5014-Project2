using System;
using TicketLibrary;

namespace TicketSystem
{
    class Program
    {
        static void Main()
        {
            // Start program 
            // Setup:
            // Only one instance of TicketStats, TicketContainer and TicketFactory used in the system
            ITicketStats ticketStats = new TicketStats();
            ITicketContainer ticketContainer = new TicketContainer();
            TicketFactory ticketFactory = new TicketFactory(ticketStats, ticketContainer);

            // Ticket #1 with two arguments. No password change request
            var staffID_1 = "JAYL";
            var description_1 = "My screen is all blue";
            ITicket ticket_1 = ticketFactory.CreateTicket(staffID_1, description_1);


            // Ticket #2 with four arguments. No password change request
            var staffID_2 = "JOHND";
            var description_2 = "Where's my mouse";
            var creatorName_2 = "John Doe";
            var email_2 = "JohnDoe@whitecliffe.com";
            ITicket ticket_2 = ticketFactory.CreateTicket(staffID_2, description_2, creatorName_2, email_2);

            // Ticket #3 with two arguments. With password change request
            var staffID_3 = "JANED";
            var description_3 = "Password change";
            ITicket ticket_3 = ticketFactory.CreateTicket(staffID_3, description_3);

            // Ticket #4 with four arguments. With password change request
            var staffID_4 = "TOMJ";
            var description_4 = "Password Change";
            var creatorName_4 = "Tom Jerry";
            var email_4 = "TJ@whitecliffe.com";
            ITicket ticket_4 = ticketFactory.CreateTicket(staffID_4, description_4, creatorName_4, email_4);
            
            TicketDisplay.DisplayAllTicketStatsAndInformation(ticketStats, ticketContainer);

            // Resolve ticket_1 and ticket 2
            var responseMessage = "Press restart button";
            var responseMessage_2 = "Mouse on the way";
            ticket_1.Resolve(responseMessage);
            ticket_2.Resolve(responseMessage_2);

            TicketDisplay.DisplayAllTicketStatsAndInformation(ticketStats, ticketContainer);

            // Reopen ticket_1, ticket_4
            ticket_1.Reopen();
            ticket_4.Reopen();

            TicketDisplay.DisplayAllTicketStatsAndInformation(ticketStats, ticketContainer);

        }
    }
}
