using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    class BloodDonorInfo
    {
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(128)")]
        public string FullName { get; set; }

        public List<InventoryItem> Inventory { get; set; }

        public List<AchievementItem> Achievements { get; set; }

        public List<BloodDonationEvent> AttendedEvents { get; set; }
    }
}
