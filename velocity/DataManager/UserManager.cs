using System.Linq;
using velocity.Generic;
using velocity.Models;

namespace velocity.DataManager
{
    public class UserManager : DataRepository<User, int>
    {

        VelocityContext ctx;

        public UserManager(VelocityContext c) : base(c)
        {
            ctx = c;
        }

        public bool LoginValidate(string bankId, string password)
        {
            var row = ctx.Set<User>().FirstOrDefault(u => u.bankId.Equals(bankId) && u.password.Equals(password));
            return row != null;
        }

    }
}
