using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.Models
{
    public class BloodDonationEvent
    {
        public int Id { get; internal set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<InventoryItem> Rewards { get; set; }
    }
}
