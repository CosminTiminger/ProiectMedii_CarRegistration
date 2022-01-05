using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Book
    {
        [Key]
        public int Phone_No { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string Full_Name { get; set; }
        public int License_Id { get; set; }
        public int Car_Id { get; set; }
        public ICollection<Cars> Car { get; set; }


    }




}


