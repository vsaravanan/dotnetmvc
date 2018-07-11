using System;
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

        public Object LoginValidate(string bankId, string password)
        {
            if ("".Equals(bankId))
                return "Bank Id can't be blank";

            if ("".Equals(password))
                return "Password can't be blank";

            var row = ctx.Set<User>().FirstOrDefault(u => u.bankId.Equals(bankId) && u.password.Equals(password));
            if (row == null)
                return "Invalid bankId / Password";
            else
                return row;
        }

    }
}
