using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketLibrary;

namespace TicketSystem
{
    public static class TicketDisplay
    {
        // Display ticket statistics and tickets information
        public static void DisplayAllTicketStatsAndInformation(ITicketStats ticketStats, ITicketContainer ticketContainer)
        {
            DisplayTicketStatistics(ticketStats);
            DisplayTickets(ticketContainer);
        }

        // Display ticket statistics
        public static void DisplayTicketStatistics(ITicketStats ticketStats)
        {
            Console.WriteLine("Displaying Ticket Statistics: \n");
            Console.WriteLine(ticketStats.GetTicketStats());
        }

        // Display all tickets information 
        public static void DisplayTickets(ITicketContainer ticketContainer)
        {
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
