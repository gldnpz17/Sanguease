
namespace SangueaseBusinessLogic.ModelMappers
{
    internal interface IInventoryItemMapper
    {
        Models.InventoryItem MapToInventoryItem(DataAccessLibrary.Models.InventoryItem inventoryItem);
    }
}