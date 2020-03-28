using System;
using System.Collections.Generic;
using Covid19.Morocco.Data.Models;

namespace Covid19.Morocco.Service
{
    public interface ICasesService
    {
        Cases Get(Guid id);
        void Add(Cases cases);
        void Update(Cases cases);
        void Delete(Cases cases);
        IEnumerable<Cases> GetAll();
        void Save();
    }
}