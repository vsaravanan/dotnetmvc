using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class ModelTemplateManager : DataRepository<ModelTemplate, int>
    {

        VelocityContext ctx;

        public ModelTemplateManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
