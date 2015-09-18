using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.State
{
    public class NewTicketStatus : TicketState
    {
        public NewTicketStatus(Ticket ticket)
            : base(ticket)
        {

        }

        public NewTicketStatus()
            : base()
        {

        }

        public override TicketStatus Status
        {
            get
            {
                return TicketStatus.New;
            }
        }

        public override bool CanChangeTo(TicketStatus toStatus)
        {
            return toStatus == TicketStatus.Accepted || toStatus == TicketStatus.Rejected;
        }

    }
}
