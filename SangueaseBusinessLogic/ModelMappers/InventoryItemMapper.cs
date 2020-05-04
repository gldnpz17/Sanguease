using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.ModelMappers
{
    internal class InventoryItemMapper : IInventoryItemMapper
    {
        internal SangueaseBusinessLogic.Models.InventoryItem MapToInventoryItem(DataAccessLibrary.Models.InventoryItem inventoryItem)
        {
            return new SangueaseBusinessLogic.Models.InventoryItem()
            {
                Id = inventoryItem.Id,
                Name = inventoryItem.Name,
                Description = inventoryItem.Description
            };
        }
    }
}
