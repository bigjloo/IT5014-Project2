using System;

namespace TicketLibrary
{
    public class Ticket
    {
        public string StaffID { get; private set; }      
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string CreatorName { get; private set; }
        public uint TicketNumber { get; private set; }
        public string Status { get; private set; }
        public string Response { get; private set; } = "Not Yet Provided";

        private static uint _ticketCounter = 0;
        private readonly ITicketStats _ticketStats; 

        public Ticket(string staffID, string description, ITicketStats ticketStats)
        {
            StaffID = staffID;
            Description = description;
            Email = "Not Specified";
            CreatorName = "Not Specified";
            _ticketStats = ticketStats;

            SetTicketCounter();
            TicketNumber = GetTicketNumber();

            SetStatus("Open");

            if(HasPasswordChangeIn(description))
            {
                ProcessPasswordChange();
                SetStatus("Closed");
            }
        }
      
        public Ticket(string staffID, string description, string creatorName, string email, ITicketStats ticketStats)
        {
            StaffID = staffID;
            Description = description;
            Email = email;
            CreatorName = creatorName;
            _ticketStats = ticketStats;

            SetTicketCounter();
            TicketNumber = GetTicketNumber();

            SetStatus("Open");

            if(HasPasswordChangeIn(description))
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

        // problem when many set at same time?
        private void SetTicketCounter()
        {
            _ticketCounter += 1;
        }

        private static uint GetTicketNumber()
        {
            var ticketNumber = _ticketCounter + 2000;
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
