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

        private const uint TicketNumberConstant = 2000;
        // _ticketCounter + 1 for every new Ticket created
        private static uint _ticketCounter = 0;

        // To call TicketStats.UpdateStats(status) whenever we update Status
        ITicketStats _ticketStats;

        // Two arguments provided from user
        public Ticket(string staffID, string description, ITicketStats ticketStats)
        {
            // Email, CreatorName default to "Not Specified" if not provided by user
            StaffID = staffID;
            Description = description;
            Email = "Not Specified";
            CreatorName = "Not Specified";
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

        public void Resolve(string message)
        {
            Respond(message);
            SetStatus("Closed");
        }

        public void Reopen()
        {
            SetStatus("Reopened");
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

        private static bool HasPasswordChangeIn(string description)
        {
            string str = description.ToLower();
            return str.Contains("password change");
        }

        private void ProcessPasswordChange()
        {
            string password = PasswordGenerator.GeneratePassword(StaffID, TicketNumber);
            var message = $"New password generated: {password}";
            Respond(message);
        }
        private void Respond(string message)
        {
            Response = message;
        }

    }
}
