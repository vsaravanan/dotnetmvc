using velocity.Models;
using velocity.Generic;
using velocity.DataManager;

namespace velocity.Controllers
{

    public class ProductTemplateController : GenericController<ProductTemplateManager, ProductTemplate, int>
    {

        public ProductTemplateManager mgr { get; set; }

        public ProductTemplateController(ProductTemplateManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }


    }
}
