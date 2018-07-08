using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class FormTemplateController : GenericController<FormTemplateManager, FormTemplate, int>
    {

        public FormTemplateManager mgr { get; set; }

        public FormTemplateController(FormTemplateManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
