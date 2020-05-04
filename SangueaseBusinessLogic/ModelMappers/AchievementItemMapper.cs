using SangueaseBusinessLogic.Models;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.ModelMappers
{
    class AchievementItemMapper : IAchievementItemMapper
    {
        public SangueaseBusinessLogic.Models.AchievementItem MapToAchievementItem(DataAccessLibrary.Models.AchievementItem achievementItem)
        {
            return new SangueaseBusinessLogic.Models.AchievementItem()
            {
                Id = achievementItem.Id,
                Name = achievementItem.Name,
                Description = achievementItem.Description
            };
        }
    }
}
