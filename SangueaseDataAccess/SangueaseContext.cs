using SangueaseDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueaseDataAccess
{
    public class SangueaseContext : DbContext
    {
        /*public SangueaseContext()
            : base("name=SangueaseDB")
        {

        }*/

        public DbSet<BDEvent> BloodDonationEvents { get; set; }
    }
}
