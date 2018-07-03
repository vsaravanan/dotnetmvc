using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using velocity.Models;

namespace velocity.Repository
{
    public class TraderRepository : ITraderRepository
    {
        static List<Trader> TraderList = new List<Trader>();

        public void Add(Trader item)
        {
            TraderList.Add(item);
        }

        public Trader Find(string key)
        {
            return TraderList
                .Where(e => e.name.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<Trader> GetAll()
        {
            return TraderList;
        }

        public void Remove(int Id)
        {
            var itemToRemove = TraderList.SingleOrDefault(r => r.id == Id);
            if (itemToRemove != null)
                TraderList.Remove(itemToRemove);
        }

        public void Update(Trader item)
        {
            var itemToUpdate = TraderList.SingleOrDefault(r => r.id == item.id);
            if (itemToUpdate != null)
            {
                itemToUpdate.name = item.name;
                itemToUpdate.salary = item.salary;
            }
        }
    }
}
