using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class BookDetail
    {
        [Key]
        public int BookDetailId { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Description { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Book Book  { get; set; }

    }
}
