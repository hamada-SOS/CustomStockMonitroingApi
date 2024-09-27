using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public string Symbol { get; set; } = string.Empty;
        //trying
        public string Company { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string Indestry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}