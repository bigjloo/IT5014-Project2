namespace TicketLibrary
{
    public interface ITicket
    {
        string CreatorName { get; }
        string Description { get; }
        string Email { get; }
        string Response { get; }
        string StaffID { get; }
        string Status { get; }
        uint TicketNumber { get; }

        void Reopen();
        void Resolve(string message);
    }
}