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
        private readonly TicketStats _ticketStats = TicketStats.getInstance();

        public Ticket(string staffID, string description)
        {
            UpdateTicketCounter();

            StaffID = staffID;
            Description = description;
            Email = "Not Specified";
            CreatorName = "Not Specified";
            TicketNumber = GenerateTicketNumber();

            UpdateStatusAndTicketStats("Open");

            if(HasPasswordChangeIn(description))
            {
                ProcessPasswordChange();
                UpdateStatusAndTicketStats("Closed");
            }
        }

        public Ticket(string staffID, string description, string creatorName, string email)
        {
            UpdateTicketCounter();

            StaffID = staffID;
            Description = description;
            Email = email;
            CreatorName = creatorName;
            TicketNumber = GenerateTicketNumber();

            UpdateStatusAndTicketStats("Open");

            if(HasPasswordChangeIn(description))
            {
                ProcessPasswordChange();
                UpdateStatusAndTicketStats("Closed");
            }
        }
        public void Resolve(string message)
        {
            Respond(message);
            UpdateStatusAndTicketStats("Closed");
        }

        public void Reopen()
        {
            UpdateStatusAndTicketStats("Reopened");
        }

        private static void UpdateTicketCounter()
        {
            _ticketCounter += 1;
        }

        private static uint GenerateTicketNumber()
        {
            var ticketNumber = _ticketCounter + 2000;
            return ticketNumber;
        }

        private void UpdateStatusAndTicketStats(string status)
        {
            Status = status;
            _ticketStats.UpdateStats(Status);
        }

        private static bool HasPasswordChangeIn(string description)
        {
            return (description.ToLower().Trim() == "password change");
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
