using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class RoleFeatureManager : DataRepository<RoleFeature, int>
    {

        VelocityContext ctx;

        public RoleFeatureManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
