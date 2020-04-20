using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class BloodDonationEvent
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(128)")]
        public string Name { get; set; }
        
        [Column(TypeName = "NVARCHAR(512)")]
        public string Description { get; set; }

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

        [Required]
        [Column(TypeName = "DATETIME2")]
        public DateTime StartDate { get; set; }
        
        [Required]
        [Column(TypeName = "DATETIME2")]
        public DateTime EndDate { get; set; }
        
        public List<InventoryItem> Rewards { get; set; }
    }
}
