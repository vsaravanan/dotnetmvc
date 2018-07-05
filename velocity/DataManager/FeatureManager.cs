using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class FeatureManager : DataRepository<Feature, int>
    {

        VelocityContext ctx;

        public FeatureManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
