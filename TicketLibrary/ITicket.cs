namespace TicketLibrary
{
    public interface ITicket
    {
        void Reopen();
        void Resolve(string message);
        void Respond(string message);
}