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
        // _ticketNumber = _ticketCounter + TicketNumberConstant
        private const uint TicketNumberConstant = 2000;        
        private static uint _ticketCounter = 0;

        // To call TicketStats.UpdateStats(status) whenever we update Status
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
        public void Reopen()
        {
            SetStatus("Reopened");
        }

        public void Resolve(string message)
        {
            Respond(message);
            SetStatus("Closed");
        }
        public void Respond(string message)
        {
            Response = message;
        }

        private void UpdateTicketCounter()
        {
            _ticketCounter += 1;
        }

        private static uint GetTicketNumber()
        {
            var ticketNumber = _ticketCounter + TicketNumberConstant;
            return ticketNumber;
        }

        private void SetStatus(string status)
        {
            Status = status;
            _ticketStats.UpdateStats(status);
        }

        // Returns true if description contains password change
        private static bool HasPasswordChangeIn(string description)
        {
            string str = description.ToLower();
            return str.Contains("password change");
        }

        private void ProcessPasswordChange()
        {
            // Calls static method GeneratePassword, constructs a string and sets to response
            string password = PasswordGenerator.GeneratePassword(StaffID, TicketNumber);
            var message = $"New password generated: {password}";
            Respond(message);
        }


    }
}
