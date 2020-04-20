using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    class Email
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(128)")]
        public string Address { get; set; }
    }
}
