using APIClientLibrary.Models;
using SangueaseDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SangueaseAPI.Controllers
{
    public class BDEventController : ApiController
    {
        // GET: api/BDEvent
        public IEnumerable<SangueaseDataAccess.Models.BDEvent> Get()
        {
            try
            {
                List<SangueaseDataAccess.Models.BDEvent> outputs = new List<SangueaseDataAccess.Models.BDEvent>();

                using (var context = new SangueaseContext())
                {
                    outputs = context.BloodDonationEvents.ToList();
                }

                return outputs;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/BDEvent/5
        public SangueaseDataAccess.Models.BDEvent Get(int id)
        {
            try
            {
                SangueaseDataAccess.Models.BDEvent output;

                using (var context = new SangueaseContext())
                {
                    output = context.BloodDonationEvents.FirstOrDefault(b => b.Id == id);
                }

                return output;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/BDEvent
        public void Post([FromBody]SangueaseDataAccess.Models.BDEvent value)
        {
            try
            {
                using (var context = new SangueaseContext())
                {
                    context.BloodDonationEvents.Add(value);

                    context.SaveChanges();
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/BDEvent/5
        public void Put(int id, [FromBody]SangueaseDataAccess.Models.BDEvent value)
        {
            try
            {
                using (var context = new SangueaseContext())
                {
                    context.BloodDonationEvents.Remove(context.BloodDonationEvents.FirstOrDefault(b => b.Id == id));
                    context.BloodDonationEvents.Add(value);

                    context.SaveChanges();
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/BDEvent/5
        public void Delete(int id)
        {
            try
            {
                using (var context = new SangueaseContext())
                {
                    context.BloodDonationEvents.Remove(
                        context.BloodDonationEvents.FirstOrDefault(b => b.Id == id)
                        );
                    context.SaveChanges();
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
