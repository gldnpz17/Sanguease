using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using SangueaseBusinessLogic.Factories;
using SangueaseBusinessLogic.ModelMappers;
using SangueaseBusinessLogic.Models;

namespace SangueaseBusinessLogic.BusinessLogic
{
    class BloodDonationEventBL
    {
        private SangueaseContext _context = new SangueaseContext();
        private IBloodDonationEventMapper _bloodDonationEventMapper = Factory.GetBloodDonationEventMapper();

        public List<BloodDonationEvent> List()
        {
            List<BloodDonationEvent> output = new List<BloodDonationEvent>();

            foreach(var item in _context.BloodDonationEvents.ToListAsync().Result)
            {
                output.Add(_bloodDonationEventMapper.MapToBloodDonationEvent(item));
            }
            return output;
        }

        public BloodDonationEvent GetById(int id)
        {
            return _bloodDonationEventMapper.MapToBloodDonationEvent(
                (from bloodDonationEvent in _context.BloodDonationEvents.ToListAsync().Result
                 where bloodDonationEvent.Id == id
                 select bloodDonationEvent).First()
                 );
        }

        public void Add(BloodDonationEventWithoutId bloodDonationEventWithoutId)
        {
            _context.BloodDonationEvents.Add();
        }
        public void Remove(int id)
        {

        }

        public void AddAttendance(string email, int bloodDonationEventId)
        {
            //add bloodDonationEvent to DB
            
            
            
        }
    }
}
