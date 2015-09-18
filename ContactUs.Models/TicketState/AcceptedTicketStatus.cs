using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.State
{
    public class AcceptedTicketStatus : TicketState
    {
        public AcceptedTicketStatus(Ticket ticket)
            : base(ticket)
        {

        }

        public AcceptedTicketStatus()
            : base()
        {

        }

        public override TicketStatus Status
        {
            get { return TicketStatus.Accepted; }
        }

        public override bool CanChangeTo(TicketStatus toStatus)
        {
            return toStatus == TicketStatus.Rejected || toStatus == TicketStatus.Closed;
        }
    }
}
