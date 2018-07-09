using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace velocity.Extn
{
    public static class Util
    {
        public static string sessionId()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

    }
}
