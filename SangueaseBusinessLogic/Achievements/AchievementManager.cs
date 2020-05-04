using SangueaseBusinessLogic.Achievements.AchievementLogics;
using SangueaseBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.Achievements
{
    internal class AchievementManager : IAchievementManager
    {
        IAchievementLogicConfig _logicConfig;

        internal AchievementManager(IAchievementLogicConfig achievementLogicConfig)
        {
            _logicConfig = achievementLogicConfig;
        }

        public void Resolve(BloodDonorInfo bloodDonorInfo)
        {
            foreach(IAchievementLogic achievementLogic in _logicConfig.AchievementLogics)
            {
                achievementLogic.Resolve(bloodDonorInfo);
            }
        }
    }
}
