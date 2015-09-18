using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactUs.Models.State;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactUs.Models
{
    public class Ticket
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        //[Required]
        //public virtual TicketState CurrentTicketState { get; set; }
        
        [InverseProperty("Ticket")]
        public virtual ICollection<TicketState> TicketStates { get; private set; }
        public DateTime LastActivityDate { get; set; }
        public string LastActivityByUser { get; set; }
        public TicketState State
        {
            get
            {
                return this.TicketStates
                    .OrderByDescending(x => x.Date)
                    .FirstOrDefault();
            }
        }

        public TicketStatus Status
        {
            get
            {
                return this.State.Status;
            }
        }

        public Ticket()
        {
            this.TicketStates = new HashSet<TicketState>();
            ChangeStatus(new NewTicketStatus(this));
        }

        internal void ChangeStatus(TicketState state)
        {
            TicketStates.Add(state);
            //CurrentTicketState = state;
        }

        public void Accept()
        {
            if (this.State.CanChangeTo(TicketStatus.Accepted))
            {
                ChangeStatus(new AcceptedTicketStatus(this));
            }
        }

        public void Close()
        {
            if (this.State.CanChangeTo(TicketStatus.Closed))
            {
                ChangeStatus(new ClosedTicketStatus(this));
            }
        }

        public void Reject()
        {
            if (this.State.CanChangeTo(TicketStatus.Rejected))
            {
                ChangeStatus(new RejectedTicketStatus(this));
            }
        }

        public bool CanChangeTo(TicketStatus toStatus)
        {
            return this.State.CanChangeTo(toStatus);
        }
    }
}
