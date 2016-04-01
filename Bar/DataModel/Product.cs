using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bar.DataModel
{
     public  class Product 
    {
        public int ProductId { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Type { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
