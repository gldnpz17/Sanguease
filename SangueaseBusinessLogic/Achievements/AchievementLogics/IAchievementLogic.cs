using SangueaseBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.Achievements.AchievementLogics
{
    internal interface IAchievementLogic
    {
        bool Resolve(BloodDonorInfo bloodDonorInfo);
    }
}
