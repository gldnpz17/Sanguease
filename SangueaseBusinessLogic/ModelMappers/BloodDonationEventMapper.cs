using SangueaseBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.ModelMappers
{
    internal class BloodDonationEventMapper : IBloodDonationEventMapper
    {
        private IInventoryItemMapper _inventoryItemMapper;

        internal BloodDonationEventMapper(IInventoryItemMapper inventoryItemMapper)
        {
            _inventoryItemMapper = inventoryItemMapper;
        }

        internal SangueaseBusinessLogic.Models.BloodDonationEvent MapToBloodDonationEvent(DataAccessLibrary.Models.BloodDonationEvent bloodDonationEvent)
        {
            List<Models.InventoryItem> rewards = new List<Models.InventoryItem>();
            foreach (var item in bloodDonationEvent.Rewards)
            {
                rewards.Add(_inventoryItemMapper.MapToInventoryItem(item));
            }

            return new SangueaseBusinessLogic.Models.BloodDonationEvent()
            {
                Id = bloodDonationEvent.Id,
                Name = bloodDonationEvent.Name,
                Description = bloodDonationEvent.Description,
                Latitude = bloodDonationEvent.Latitude,
                Longitude = bloodDonationEvent.Longitude,
                StartDate = bloodDonationEvent.StartDate,
                EndDate = bloodDonationEvent.EndDate,
                Rewards = rewards
            };
        }
    }
}
