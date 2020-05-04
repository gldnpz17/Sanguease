using SangueaseBusinessLogic.Achievements;
using SangueaseBusinessLogic.ModelMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.Factories
{
    internal static class Factory
    {
        internal static IAchievementManager GetAchievementManager()
        {
            return new AchievementManager(GetAchievementLogicConfig());
        }
        internal static IAchievementItemMapper GetAchievementItemMapper()
        {
            return new AchievementItemMapper();
        }
        internal static IInventoryItemMapper GetInventoryItemMapper()
        {
            return new InventoryItemMapper();
        }
        internal static IBloodDonationEventMapper GetBloodDonationEventMapper()
        {
            return new BloodDonationEventMapper(GetInventoryItemMapper());
        }

        private static IAchievementLogicConfig GetAchievementLogicConfig()
        {
            return new AchievementLogicConfig();
        }
    }
}
