﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using velocity.Models.Repository;

namespace velocity.Models.DataManager
{
    public class UserManager : IDataRepository<User, int>
    {

        VelocityContext ctx;

        public UserManager(VelocityContext c)
        {
            ctx = c;
        }


        public IEnumerable<User> GetAll()
        {
            var users = ctx.User.ToList();
            return users;
        }

        public User Get(int id)
        {
            var user = ctx.User.FirstOrDefault(b => b.id == id);
            return user;
        }

        public User Find(string key)
        {
            return ctx.User
                .Where(e => e.bankId.Equals(key))
                .SingleOrDefault();
        }


        public long Add(User b)
        {
            ctx.User.Add(b);
            long id = ctx.SaveChanges();
            return id;
        }

        public long Delete(int id)
        {
            int deletedId = 0;
            var user = ctx.User.FirstOrDefault(b => b.id == id);
            if (user != null)
            {
                ctx.User.Remove(user);
                deletedId = ctx.SaveChanges();
            }
            return deletedId;
        }

        public long Update(int id, User item)
        {
            long updId = 0;
            var user = ctx.User.Find(id);
            if (user != null)
            {
                user.bankId = item.bankId;
                user.username = item.username;
                user.password = item.password;
                user.isActive = item.isActive;
                user.isMaker = item.isMaker;
                user.makerDt = item.makerDt;
                user.makerBy = item.makerBy;
                user.checkDt = item.checkDt;
                user.checkBy = item.checkBy;
                updId = ctx.SaveChanges();
            }
            return updId;
        }
    }
}
