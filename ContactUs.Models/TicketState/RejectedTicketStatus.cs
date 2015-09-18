using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.State
{
    [Table("RejectedTicketState")]
    public class RejectedTicketStatus : TicketState
    {
        public string Reason { get; set; }

        public RejectedTicketStatus(Ticket ticket)
            : base(ticket)
        {

        }

        public RejectedTicketStatus()
            : base()
        {

        }

        public override TicketStatus Status
        {
            get { return TicketStatus.Rejected; }
        }

        public override bool CanChangeTo(TicketStatus toStatus)
        {
            return false;
        }
    }
}
