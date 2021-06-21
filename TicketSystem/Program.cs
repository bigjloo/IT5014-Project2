using System;
using TicketLibrary;

namespace TicketSystem
{
    class Program
    {
        static void Main()
        {
            // Ticket #1 with two arguements
            string staffID_1 = "JAYL";
            string description_1 = "My screen is all blue";
            Ticket ticket_1 = AppLogic.CreateTicket(staffID_1, description_1);


            // Ticket #2 with four arguements
            string staffID_2 = "JOHND";
            string description_2 = "Where's my mouse";
            string creatorName_2 = "John Doe";
            string email_2 = "JohnDoe@whitecliffe.com";
            Ticket ticket_2 = AppLogic.CreateTicket(staffID_2, description_2, creatorName_2, email_2);

            // Ticket #3 with password change request
            string staffID_3 = "JANED";
            string description_3 = "Password change";
            Ticket ticket_3 = AppLogic.CreateTicket(staffID_3, description_3);

            AppLogic.DisplayTicketStatsAndInformation();

            // Resolve ticket_1 and ticket 2
            string responseMessage = "Press restart button";
            string responseMessage_2 = "Mouse sent";
            ticket_1.Resolve(responseMessage);
            ticket_2.Resolve(responseMessage_2);

            AppLogic.DisplayTicketStatsAndInformation();

            // Reopen ticket_1
            ticket_1.Reopen();

            AppLogic.DisplayTicketStatsAndInformation();

        }
    }
}
