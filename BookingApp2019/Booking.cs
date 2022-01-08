using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookingApp2019
{
    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NationalId { get; set; }
        public string FullName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BookingDate { get; set; }

    }
}
