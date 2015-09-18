using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.State
{
    public class ClosedTicketStatus : TicketState
    {
        public ClosedTicketStatus(Ticket ticket)
            : base(ticket)
        {

        }

        public ClosedTicketStatus()
            : base()
        {

        }

        public override TicketStatus Status
        {
            get { return TicketStatus.Closed; }
        }

        public override bool CanChangeTo(TicketStatus toStatus)
        {
            return false;
        }
    }
}
