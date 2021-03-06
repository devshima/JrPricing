﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class Hikari : SuperExpressSurcharge
    {
        public int value => seatCharge.value;

        public string label => "ひかり";

        public SeatCharge getSeatCharge => this.seatCharge;

        private readonly SeatCharge seatCharge;
        public Hikari(SeatCharge seat)
        {
            this.seatCharge = seat;
        }

    }
}
