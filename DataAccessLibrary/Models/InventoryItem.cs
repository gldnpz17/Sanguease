using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    class InventoryItem
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(128)")]
        public string Name { get; set; }
    }
}
