﻿using System.Collections.Generic;
using velocity.Models;

namespace velocity.Repository
{
    public interface ITraderRepository
    {
        void Add(Trader item);
        IEnumerable<Trader> GetAll();
        Trader Find(string key);
        void Remove(int id);
        void Update(Trader item);
    }
}
