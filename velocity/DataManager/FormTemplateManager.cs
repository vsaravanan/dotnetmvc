using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class FormTemplateManager : DataRepository<FormTemplate, int>
    {

        VelocityContext ctx;

        public FormTemplateManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }
    }
}
