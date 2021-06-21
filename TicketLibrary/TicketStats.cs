using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    
    // Stores state of Ticket statistics
    public class TicketStats : ITicketStats
    {
        private static TicketStats _instance = new TicketStats();
        private static uint _created { get; set; } = 0;
        private static uint _closed { get; set; } = 0;
        private static uint _opened { get; set; } = 0;

        private TicketStats() { }

        public static TicketStats GetInstance()
        {
            return _instance;
        }

        public uint GetCreated()
        {
            return _created;
        }

        public uint GetClosed()
        {
            return _closed;
        }

        public uint GetOpened()
        {
            return _opened;
        }

        public void UpdateStats(string status)
        {
            switch (status)
            {
                case "Open":
                    _created += 1;
                    _opened += 1;
                    break;

                case "Closed":
                    _opened -= 1;
                    _closed += 1;
                    break;

                case "Reopened":
                    _opened += 1;
                    _closed -= 1;
                    break;
            }
        }

        public string GetTicketStats()
        {   
            //BEFORE
            //Console.WriteLine("Displaying Ticket Statistics");
            //Console.WriteLine("");
            //Console.WriteLine($"Tickets Created: {Created}");
            //Console.WriteLine($"Tickets Resolved: {Closed}");
            //Console.WriteLine($"Tickets To Solve: {Opened}");
            //Console.WriteLine("");
            string ticketStatistics = $"Tickets Created: {_created}\nTickets Resolved: {_closed}\nTickets To Solve: {_opened}\n";
            return ticketStatistics;
        }

        
    }
}
