using System.Collections.Generic;
using System.Threading.Tasks;
using velocity.Generic;
using velocity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace velocity.DataManager
{
    public class NamedBankingProductAttributeManager : DataRepository<NamedBankingProductAttribute, int>
    {

        VelocityContext ctx;

        public NamedBankingProductAttributeManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }

        public async Task<IDictionary<string, List<string>>>  GetSectionFields()
        {

            IEnumerable<NamedBankingProductAttribute> list = await ctx.Set<NamedBankingProductAttribute>().AsNoTracking().ToListAsync();

            //IQueryable<NamedBankingProductAttribute> qlist = list.AsQueryable();

            //var o = (from n in qlist
            //         where n.section != null
            //         orderby n.section, n.description
            //         select new { n.section, n.description }).Distinct();

            IDictionary<string, List<string>> di = new Dictionary<string, List<string>>();

            foreach (NamedBankingProductAttribute n in list)
            {
                if (n.section != null)
                {
                    if (di.ContainsKey(n.section))
                    {
                        List<string> tmp = di[n.section];
                        tmp.Add(n.description);
                        di[n.section] = tmp;
                    }
                    else
                    {
                        List<string> tmp = new List<string>();
                        tmp.Add(n.description);
                        di.Add(n.section, tmp);
                    }

                    //System.Diagnostics.Debug.WriteLine(n.section + " " + n.description);

                }
            } 


            return di;
        }

    }
}
