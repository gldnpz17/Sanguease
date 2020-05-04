
namespace SangueaseBusinessLogic.ModelMappers
{
    internal interface IBloodDonationEventMapper
    {
        Models.BloodDonationEvent MapToBloodDonationEvent(DataAccessLibrary.Models.BloodDonationEvent bloodDonationEvent);
    }
}