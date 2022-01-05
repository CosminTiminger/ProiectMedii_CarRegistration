using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Driver_Detailss
    {
        [Key]
        public int License_Id { get; set; }
        public string Full_Name { get; set; }
        public int Post_Code { get; set; }
        public int Phone_No { get; set; }
        public DateTime Birth_Date { get; set; }
        public string License_Class { get; set; }
        public string Email { get; set; }
        public ICollection<Driver_Detailss> Drivers{ get; set; }





    }
}
