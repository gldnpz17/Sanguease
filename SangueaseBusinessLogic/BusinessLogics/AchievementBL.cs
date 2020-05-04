using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SangueaseBusinessLogic.Achievements;
using SangueaseBusinessLogic.Factories;
using SangueaseBusinessLogic.Models;
using DataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using SangueaseBusinessLogic.ModelMappers;

namespace SangueaseBusinessLogic.BusinessLogic
{
    class AchievementBL
    {
        private SangueaseContext _context = new SangueaseContext();
        private IAchievementItemMapper _achievementItemMapper;

        public AchievementBL()
        {
            _achievementItemMapper = Factory.GetAchievementItemMapper();
        }

        public List<AchievementItem> List()
        {
            List<AchievementItem> output = new List<AchievementItem>();
            foreach(var item in _context.Achievements.ToListAsync().Result)
            {
                output.Add(_achievementItemMapper.MapToAchievementItem(item));
            }

            return output;
        }
        public List<AchievementItem> ListOwnedAchievement(string authId)
        {
            List<AchievementItem> output = new List<AchievementItem>();

            foreach (var item in 
                (from bloodDonor in _context.BloodDonors.ToListAsync().Result
                 where bloodDonor.AuthId == authId
                 select bloodDonor).First().Achievements)
            {
                output.Add(_achievementItemMapper.MapToAchievementItem(item));
            }

            return output;
        }
        public AchievementItem GetById(int Id)
        {
            return _achievementItemMapper.MapToAchievementItem(
                (from achievement in _context.Achievements.ToListAsync().Result
                 where achievement.Id == Id
                 select achievement).First()
                );
        }
    }
}
