using System;
using TicketLibrary;

namespace TicketSystem
{
    class Program
    {
        static void Main()
        {
            // Ticket #1 with two arguements
            string staffID_1 = "JayL";
            string description_1 = "Blue Screen. Help!";
            Ticket ticket_1 = CreateTicket(staffID_1, description_1);

            // Ticket #2 with four arguements
            string staffID_2 = "JohnD";
            string description_2 = "Youtube taking up all the space on the screen";
            string creatorName_2 = "John Doe";
            string email_2 = "JohnDoe@whitecliffe.com";
            Ticket ticket_2 = CreateTicket(staffID_2, description_2, creatorName_2, email_2);

            // Ticket #3 with password change request
            string staffID_3 = "JaneD";
            string description_3 = "Password change";
            Ticket ticket_3 = CreateTicket(staffID_3, description_3);

            DisplayTicketStatsAndInformation();

            // Resolve ticket_1 and ticket 2
            string responseMessage = "Press restart button";
            string responseMessage_2 = "Click the 'X' on the top right corner of the screen";
            ticket_1.Resolve(responseMessage);
            ticket_2.Resolve(responseMessage_2);

            DisplayTicketStatsAndInformation();

            // Reopen ticket_1
            ticket_1.Reopen();

            DisplayTicketStatsAndInformation();

        }

        private static Ticket CreateTicket(string staffID, string description)
        {
            Ticket ticket = new Ticket(staffID, description);
            TicketContainer ticketContainer = TicketContainer.getInstance();
            ticketContainer.AddTicket(ticket);
            
            return ticket;
        }

        private static Ticket CreateTicket(string staffID, string description, string creatorName, string email)
        {
            Ticket ticket = new Ticket(staffID, description, creatorName, email);
            TicketContainer ticketContainer = TicketContainer.getInstance();
            ticketContainer.AddTicket(ticket);

            return ticket;
        }

        private static void DisplayTicketStatsAndInformation()
        {
            //BEFORE
            //TicketStats.DisplayStats();
            //TicketContainer.DisplayAllTickets();

            Console.WriteLine("Displaying Ticket Statistics:\n");
            Console.WriteLine(TicketStats.GetTicketStats());
            var tickets = TicketContainer.GetTickets();

            Console.WriteLine("Printing Tickets:");
            Console.WriteLine("");

            foreach(Ticket ticket in tickets)
            {
                Console.WriteLine($"Ticket Number: {ticket.TicketNumber}");
                Console.WriteLine($"Ticket Creator: {ticket.CreatorName}");
                Console.WriteLine($"Staff ID: {ticket.StaffID}");
                Console.WriteLine($"Email Address: {ticket.Email}");
                Console.WriteLine($"Description: {ticket.Description}");
                Console.WriteLine($"Response: {ticket.Response}");
                Console.WriteLine($"Ticket Status: {ticket.Status}");
                Console.WriteLine("");
            }
        }

    }
}
