﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarRentalDetailDto:IDto
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }


        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
