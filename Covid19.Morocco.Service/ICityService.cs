using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Covid19.Morocco.Data.Models;

namespace Covid19.Morocco.Service
{
    public interface ICityService
    {
        City Get(Guid id);
        void Add(City city);
        void Update(City city);
        void Delete(City city);
        IEnumerable<City> GetAll();
        IEnumerable<City> GetMany(Expression<Func<City, bool>> where);
        void Save();
    }
}