﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JrPricingDomain.Model
{
    public class GroupDiscount
    {
        private readonly Trip trip;
        private readonly BoardingDate boardingDate;
        private const double roundDownNumber = 0.1;

        public GroupDiscount(Trip trip, BoardingDate boardingDate)
        {
            this.trip = trip;
            this.boardingDate = boardingDate;
        }

        public int value()
        {
            GroupDiscountRate groupDiscountRate = boardingDate.duringNewYearHolidaysPeriod() ? new GroupDiscountRate(0.1) : new GroupDiscountRate(0.15);
            var discounted = (int)Math.Floor((this.trip.value() * groupDiscountRate.value) * roundDownNumber) * 10;
            return discounted;
        }
    }
}
