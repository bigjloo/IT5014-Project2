using System;
using TicketLibrary;

namespace TicketSystem
{
    public class AppLogic
    {
        public static Ticket CreateTicket(string staffID, string description, TicketStats ticketStats, TicketContainer ticketContainer)
        {
             
            Ticket ticket = new Ticket(staffID, description, ticketStats);
            ticketContainer.AddTicket(ticket);

            return ticket;
        }

        public static Ticket CreateTicket(string staffID, string description, string creatorName, string email, TicketStats ticketStats, TicketContainer ticketContainer)
        {
            Ticket ticket = new Ticket(staffID, description, creatorName, email, ticketStats);
            ticketContainer.AddTicket(ticket);

            return ticket;
        }

        public static void DisplayTicketStatsAndInformation(TicketStats ticketStats, TicketContainer ticketContainer)
        {
            PrintAllTicketStatistics(ticketStats);
            PrintAllTicketObjects(ticketContainer);  
        }
        public static void PrintAllTicketStatistics(TicketStats ticketStats)
        {
            Console.WriteLine("Displaying Ticket Statistics: \n");
            Console.WriteLine(ticketStats.GetTicketStats());
        }
        public static void PrintAllTicketObjects(TicketContainer ticketContainer)
        {
            var tickets = ticketContainer.GetTickets();

            Console.WriteLine("Printing Tickets: \n");
            foreach(Ticket ticket in tickets)
            {
                Console.WriteLine($"Ticket Number: {ticket.TicketNumber}");
                Console.WriteLine($"Ticket Creator: {ticket.CreatorName}");
                Console.WriteLine($"Staff ID: {ticket.StaffID}");
                Console.WriteLine($"Email Address: {ticket.Email}");
                Console.WriteLine($"Description: {ticket.Description}");
                Console.WriteLine($"Response: {ticket.Response}");
                Console.WriteLine($"Ticket Status: {ticket.Status} \n");
            }
        }

        
    }
}
