using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Bar.DataModel
{
    public  class Tara
    {

        public int TaraId { get; set; }
        [MaxLength(256)]
        [Required]
        public string Type { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double ReUse_time { get; set; }
    }
}
