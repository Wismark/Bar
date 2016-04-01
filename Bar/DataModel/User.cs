using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bar.DataModel
{
    public class User
    {
        public int UserId { get; set; }
        public double Salary { get; set; }
        public double Tip { get; set; }
        [MaxLength(256)]
        public string Qualification { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public bool AccessToTheWarehouse { get; set; }

    }
}
