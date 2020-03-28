using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Infrastructure;

namespace Covid19.Morocco.Repository
{
    public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        public RegionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}