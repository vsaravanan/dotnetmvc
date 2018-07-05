using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{
    public class RoleFeatureController : GenericController<RoleFeatureManager, RoleFeature, int>
    {
        public RoleFeatureManager mgr { get; set; }

        public RoleFeatureController(RoleFeatureManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }

    }
}
