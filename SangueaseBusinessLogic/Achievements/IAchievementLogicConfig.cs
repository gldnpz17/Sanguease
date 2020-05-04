using SangueaseBusinessLogic.Achievements.AchievementLogics;
using System.Collections.Generic;

namespace SangueaseBusinessLogic.Achievements
{
    internal interface IAchievementLogicConfig
    {
        List<IAchievementLogic> AchievementLogics { get; }
    }
}