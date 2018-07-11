using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class MifidManager : DataRepository<Mifid, int>
    {

        VelocityContext ctx;

        public MifidManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
