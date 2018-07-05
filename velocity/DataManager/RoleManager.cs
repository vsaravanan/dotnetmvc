using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class RoleManager : DataRepository<Role, int>
    {

        VelocityContext ctx;

        public RoleManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
