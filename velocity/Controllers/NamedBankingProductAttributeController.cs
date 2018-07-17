using velocity.Models;
using velocity.Generic;
using velocity.DataManager;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace velocity.Controllers
{

    public class NamedBankingProductAttributeController : GenericController<NamedBankingProductAttributeManager, NamedBankingProductAttribute, int>
    {

        public NamedBankingProductAttributeManager mgr { get; set; }

        public NamedBankingProductAttributeController(NamedBankingProductAttributeManager inmgr) : base(inmgr)
        {
            mgr = inmgr;
        }

        [Route("[controller]/GetSectionFields")]
        public Task<IDictionary<string, List<string>>> GetSectionFields()
        {
            CheckAuthentication();
            return mgr.GetSectionFields();
        }

    }
}
