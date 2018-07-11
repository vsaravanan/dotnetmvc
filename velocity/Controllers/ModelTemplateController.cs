using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class ModelTemplateController : GenericController<ModelTemplateManager, ModelTemplate, int>
    {

        public ModelTemplateManager mgr { get; set; }

        public ModelTemplateController(ModelTemplateManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
