using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = " Symbol sould be at lest 5 char")]
        [MaxLength(380, ErrorMessage = " Symbol sould not be more then  380 char")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = " Comapny sould be at lest 5 char")]
        [MaxLength(50, ErrorMessage = " Comapny sould not be more then  50 char")]
        public string Company { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.0001, 1.00)]
        public decimal LastDiv { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = " Indestry sould be at lest 5 char")]
        [MaxLength(380, ErrorMessage = " Indestry sould not be more then  380 char")]
        public string Indestry { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000000)]
        public long MarketCap { get; set; }
    }
}