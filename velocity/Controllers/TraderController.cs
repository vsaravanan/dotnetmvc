using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TraderDataAccess;


namespace velocity.Controllers
{
    public class TraderController : ApiController
    {
        public IEnumerable<Trader> Get()
        {
            using (velocityEntities entities = new velocityEntities())
            {
                return entities.Traders.ToList();
            }
        }
        public Trader Get(int id)
        {
            using (velocityEntities entities = new velocityEntities())
            {
                return entities.Traders.FirstOrDefault(e => e.id == id);
            }
        }
    }
}
