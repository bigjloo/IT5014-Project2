using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    // Singleton TicketContainer
    // Stores Tickets in a List
    public class TicketContainer
    {
        private static TicketContainer _instance = new TicketContainer();
        private static List<Ticket> _tickets = new List<Ticket>();
        private TicketContainer(){}
        public static TicketContainer getInstance()
        {
            return _instance;
        }

        // BEFORE
        //public static void DisplayAllTickets()
        //{
        //    Console.WriteLine("Printing Tickets:");
        //    Console.WriteLine("");

        //    foreach(Ticket ticket in _tickets)
        //    {
        //        Console.WriteLine($"Ticket Number: {ticket.TicketNumber}");
        //        Console.WriteLine($"Ticket Creator: {ticket.CreatorName}");
        //        Console.WriteLine($"Staff ID: {ticket.StaffID}");
        //        Console.WriteLine($"Email Address: {ticket.Email}");
        //        Console.WriteLine($"Description: {ticket.Description}");
        //        Console.WriteLine($"Response: {ticket.Response}");
        //        Console.WriteLine($"Ticket Status: {ticket.Status}");
        //        Console.WriteLine("");
        //    }
        //}

        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public static List<Ticket> GetTickets()
        {
            return _tickets;
        }
    }
}
