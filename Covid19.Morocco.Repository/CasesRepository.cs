using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Infrastructure;

namespace Covid19.Morocco.Repository
{
    public class CasesRepository : RepositoryBase<Cases>, ICasesRepository
    {
        public CasesRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

    }
}