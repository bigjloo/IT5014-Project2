using System;
using TicketLibrary;

namespace TicketSystem
{
    class Program
    {
        static void Main()
        {
            // Start program 
            // Create one instance of TicketStats and TicketContainer
            ITicketStats ticketStats = Factory.CreateTicketStats();
            ITicketContainer ticketContainer = Factory.CreateTicketContainer();

            // Ticket #1 with two arguments, no password change request
            string staffID_1 = "JAYL";
            string description_1 = "My screen is all blue";
            ITicket ticket_1 = Factory.CreateTicket(staffID_1, description_1, ticketStats, ticketContainer);


            // Ticket #2 with four arguments, no password change request
            string staffID_2 = "JOHND";
            string description_2 = "Where's my mouse";
            string creatorName_2 = "John Doe";
            string email_2 = "JohnDoe@whitecliffe.com";
            ITicket ticket_2 = Factory.CreateTicket(staffID_2, description_2, creatorName_2, email_2, ticketStats, ticketContainer);

            // Ticket #3 with two arguments, with password change request
            string staffID_3 = "JANED";
            string description_3 = "Password change";
            ITicket ticket_3 = Factory.CreateTicket(staffID_3, description_3, ticketStats, ticketContainer);

            // Ticket #4
            string staffID_4 = "TOMJ";
            string description_4 = "Password Change";
            string creatorName_4 = "Tom Jerry";
            string email_4 = "TJ@whitecliffe.com";
            ITicket ticket_4 = Factory.CreateTicket(staffID_4, description_4, creatorName_4, email_4, ticketStats, ticketContainer);
            
            Display.DisplayTicketStatsAndInformation(ticketStats, ticketContainer);

            // Resolve ticket_1 and ticket 2
            string responseMessage = "Press restart button";
            string responseMessage_2 = "Mouse on the way";
            ticket_1.Resolve(responseMessage);
            ticket_2.Resolve(responseMessage_2);

            Display.DisplayTicketStatsAndInformation(ticketStats, ticketContainer);

            // Reopen ticket_1
            ticket_1.Reopen();
            ticket_4.Reopen();

            Display.DisplayTicketStatsAndInformation(ticketStats, ticketContainer);

        }

    }
}
