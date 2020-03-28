using Covid19.Morocco.Data;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Infrastructure;

namespace Covid19.Morocco.Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}