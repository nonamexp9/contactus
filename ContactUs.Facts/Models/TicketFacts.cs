using ContactUs.Models;
using ContactUs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactUs.Facts.Models
{
    public class TicketFacts
    {
        // 1. NewTicketStatus_ShouldBeNew
        // 2. NewTicket_AbleToChangeToAcceptedAndRejected_ButNotClosed
        // 3. AcceptedTicket_AbleToChangeToClosedOrRejected
        // 4. RejectedAndClosedTicket_CannotChangeStatusAnymore

        public class NewTicketStatus
        {
            [Fact]
            public void NewTicketStatus_ShouldBeNew()
            {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";

                Assert.NotNull(t.Status);
                Assert.True(t.Status == TicketStatus.New);
            }

            [Fact]
            public void NewTicket_AbleToChangeToAcceptedAndRejected_ButNotClosed()
            {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";

                Assert.True(t.CanChangeTo(TicketStatus.Accepted));
                Assert.True(t.CanChangeTo(TicketStatus.Rejected));
                Assert.False(t.CanChangeTo(TicketStatus.Closed));
                Assert.False(t.CanChangeTo(TicketStatus.New));
            }

            [Fact]
            public void AcceptedTicket_AbleToChangeToClosedOrRejected()
            {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                t.Accept();

                Assert.True(t.Status == TicketStatus.Accepted);
                Assert.True(t.CanChangeTo(TicketStatus.Rejected));
                Assert.True(t.CanChangeTo(TicketStatus.Closed));

                Assert.False(t.CanChangeTo(TicketStatus.New));
                Assert.False(t.CanChangeTo(TicketStatus.Accepted));
            }

            [Fact]
            public void RejectedTicket_CannotChangeStatusAnymore()
            {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                t.Reject();

                Assert.True(t.Status == TicketStatus.Rejected);
                Assert.False(t.CanChangeTo(TicketStatus.Rejected));
                Assert.False(t.CanChangeTo(TicketStatus.Closed));
                Assert.False(t.CanChangeTo(TicketStatus.New));
                Assert.False(t.CanChangeTo(TicketStatus.Accepted));
            }

            [Fact]
            public void ClosedTicket_CannotChangeStatusAnymore()
            {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                t.Accept();
                t.Close();

                Assert.True(t.Status == TicketStatus.Closed);
                Assert.False(t.CanChangeTo(TicketStatus.Rejected));
                Assert.False(t.CanChangeTo(TicketStatus.Closed));
                Assert.False(t.CanChangeTo(TicketStatus.New));
                Assert.False(t.CanChangeTo(TicketStatus.Accepted));
            }
        }
    }
}
