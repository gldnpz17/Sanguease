using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.Models
{
    class BloodDonorInfo : BloodDonorStats
    {
        public string FullName { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<AchievementItem> Achievements { get; set; }
        public List<BloodDonationEvent> AttendedEvents { get; set; }
    }
}
