using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    public interface ITicketStats
    {
        void UpdateStats(string status);
    }
}
