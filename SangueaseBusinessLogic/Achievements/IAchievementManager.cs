using SangueaseBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.Achievements
{
    internal interface IAchievementManager
    {
        void Resolve(BloodDonorInfo bloodDonorInfo);
    }
}
