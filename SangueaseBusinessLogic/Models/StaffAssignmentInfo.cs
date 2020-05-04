using System;
using System.Collections.Generic;
using System.Text;

namespace SangueaseBusinessLogic.DataTransferObjects
{
    class StaffAssignmentInfo
    {
        public int Id { get; private set; }
        
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        internal StaffAssignmentInfo(int id, DateTime startDate, DateTime endDate)
        {

        }
        internal StaffAssignmentInfo(DateTime startDate, DateTime endDate)
        {

        }
    }
}
