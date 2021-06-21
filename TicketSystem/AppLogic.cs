using System;
using TicketLibrary;

namespace TicketSystem
{
    public class AppLogic
    {
        public static Ticket CreateTicket(string staffID, string description)
        {
            Ticket ticket = new Ticket(staffID, description, TicketStats.GetInstance());
            TicketContainer ticketContainer = TicketContainer.GetInstance();
            ticketContainer.AddTicket(ticket);

            return ticket;
        }

        public static Ticket CreateTicket(string staffID, string description, string creatorName, string email)
        {
            Ticket ticket = new Ticket(staffID, description, creatorName, email, TicketStats.GetInstance());
            TicketContainer ticketContainer = TicketContainer.GetInstance();
            ticketContainer.AddTicket(ticket);

            return ticket;
        }

        public static void DisplayTicketStatsAndInformation()
        {
            PrintAllTicketStatistics();
            PrintAllTicketObjects();  
        }
        public static void PrintAllTicketStatistics()
        {
            TicketStats ticketStats = TicketStats.GetInstance();
            Console.WriteLine("Displaying Ticket Statistics: \n");
            Console.WriteLine(ticketStats.GetTicketStats());
        }
        public static void PrintAllTicketObjects()
        {
            var ticketContainer = TicketContainer.GetInstance();
            var tickets = ticketContainer.GetTickets();

            Console.WriteLine("Printing Tickets: \n");
            foreach (Ticket ticket in tickets)
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
