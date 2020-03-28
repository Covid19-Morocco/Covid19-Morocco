using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Covid19.Morocco.Data.Models;

namespace Covid19.Morocco.Service
{
    public interface IRegionService
    {
        Region Get(Guid id);
        void Add(Region region);
        void Update(Region region);
        void Delete(Region region);
        IEnumerable<Region> GetAll();
        IEnumerable<Region> GetMany(Expression<Func<Region, bool>> where);
        void Save();
    }
}