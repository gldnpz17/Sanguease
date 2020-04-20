using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    class Role
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(32)")]
        public string Name { get; set; }
    }
}
