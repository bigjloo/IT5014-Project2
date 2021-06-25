using System;

namespace TicketLibrary
{
    public class Ticket : ITicket
    {
        // Private setters so properties cannot be set from outside class
        public string StaffID { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string CreatorName { get; private set; }
        public uint TicketNumber { get; private set; }
        public string Status { get; private set; }
        public string Response { get; private set; } = "Not Yet Provided";

        // _ticketCounter + 1 for every new Ticket created
        private const uint TicketNumberConstant = 2000;
        private static uint _ticketCounter = 0;

        // To call UpdateStats(status) whenever Status is updated
        readonly ITicketStats _ticketStats;

        // Two arguments provided from user
        public Ticket(string staffID, string description, ITicketStats ticketStats)
        {
            // Email, CreatorName default to "Not Specified" if not provided by user
            StaffID = staffID;
            Description = description;
            Email = "Not Specified";
            CreatorName = "Not Specified";
            _ticketStats = ticketStats;

            // Update ticket counter and assign ticket number
            UpdateTicketCounter();
            TicketNumber = GetTicketNumber();

            SetStatus("Open");

            // If description contains password change, process password change procedure
            if (HasPasswordChangeIn(description))
            {
                ProcessPasswordChange();
                SetStatus("Closed");
            }
        }

        // Four arguments provided from user
        public Ticket(string staffID, string description, string email, string creatorName, ITicketStats ticketStats)
        {
            StaffID = staffID;
            Description = description;
            Email = email;
            CreatorName = creatorName;
            _ticketStats = ticketStats;

            UpdateTicketCounter();
            TicketNumber = GetTicketNumber();

            SetStatus("Open");

            if (HasPasswordChangeIn(description))
            {
                ProcessPasswordChange();
                SetStatus("Closed");
            }
        }
        
        // Sets status = "Reopened"
        public void Reopen()
        {
            SetStatus("Reopened");
        }

        // Sets ticket.Response = message and sets Status to "Closed"
        public void Resolve(string message)
        {
            Respond(message);
            SetStatus("Closed");
        }

        // Sets ticket.Response = message
        public void Respond(string message)
        {
            Response = message;
        }

        // Increase _ticketCounter by 1
        private void UpdateTicketCounter()
        {
            _ticketCounter += 1;
        }

        // Returns _ticketCounter + TicketNumberConstant
        private static uint GetTicketNumber()
        {
            var ticketNumber = _ticketCounter + TicketNumberConstant;
            return ticketNumber;
        }

        // Sets Status and calls UpdateStats() from ticketStats
        private void SetStatus(string status)
        {
            Status = status;
            _ticketStats.UpdateStats(status);
        }

        // Returns true if description contains "password change"
        private static bool HasPasswordChangeIn(string description)
        {
            string str = description.ToLower();
            return str.Contains("password change");
        }

        private void ProcessPasswordChange()
        {
            // Gets password from PasswordGenerator
            string password = PasswordGenerator.GeneratePassword(StaffID, TicketNumber);
            
            // Constructs message string with generated password
            var message = $"New password generated: {password}";

            // Sets response = message
            Respond(message);
        }
    }
}
