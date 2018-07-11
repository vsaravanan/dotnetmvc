using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class ProductTemplateManager : DataRepository<ProductTemplate, int>
    {

        VelocityContext ctx;

        public ProductTemplateManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
