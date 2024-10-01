using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = " Title sould be at lest 5 char")]
        [MaxLength(20, ErrorMessage = " Content sould not be more then  20 char")]

        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = " Content sould be at lest 5 char")]
        [MaxLength(380, ErrorMessage = " Content sould not be more then  380 char")]
        public string Content { get; set; } = string.Empty;
    }
}