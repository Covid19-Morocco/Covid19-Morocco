using Covid19.Morocco.Data;

namespace Covid19.Morocco.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        CoronaContext _dbContext;

        public CoronaContext Init() => _dbContext ?? (_dbContext = new CoronaContext());

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }

    }
}