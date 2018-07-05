using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class FeatureController : GenericController<FeatureManager, Feature, int>
    {

        public FeatureManager mgr { get; set; }

        public FeatureController(FeatureManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
