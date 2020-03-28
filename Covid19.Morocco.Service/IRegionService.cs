using System;
using System.Collections.Generic;
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
        void Save();
    }
}