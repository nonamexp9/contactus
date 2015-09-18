using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.State
{
    public abstract class TicketState
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        
        [InverseProperty("TicketStates")]
        public virtual Ticket Ticket { get; set; }

        public TicketState()
        {

        }

        public TicketState(Ticket ticket)
        {
            this.Ticket = ticket;
            this.Date = DateTime.Now;
        }

        public abstract TicketStatus Status { get; }
        public abstract bool CanChangeTo(TicketStatus toStatus);
    }
}
