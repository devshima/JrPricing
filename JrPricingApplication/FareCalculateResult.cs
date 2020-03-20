using JrPricingDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingApplication
{
    public class FareCalculateResult
    {
        private readonly Ticket ticket;
        public FareCalculateResult(Ticket ticket)
        {
            this.ticket = ticket;
        }

        public int amount()
        {
            return ticket.Amount();
        }

    }
}
