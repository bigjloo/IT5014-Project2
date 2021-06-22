using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketLibrary;

namespace TicketSystem
{
    public class Display
    {
        public static void DisplayTicketStatsAndInformation(ITicketStats ticketStats, ITicketContainer ticketContainer)
        {
            DisplayTicketStatistics(ticketStats);
            DisplayAllTicketInformation(ticketContainer);
        }
        public static void DisplayTicketStatistics(ITicketStats ticketStats)
        {
            Console.WriteLine("Displaying Ticket Statistics: \n");
            Console.WriteLine(ticketStats.GetTicketStats());
        }
        public static void DisplayAllTicketInformation(ITicketContainer ticketContainer)
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
