using SangueaseBusinessLogic.Achievements.AchievementLogics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.Achievements
{
    internal class AchievementLogicConfig : IAchievementLogicConfig
    {
        public List<IAchievementLogic> AchievementLogics { get; } = new List<IAchievementLogic>() {
            new FirstBloodLogic()
        };
    }
}
