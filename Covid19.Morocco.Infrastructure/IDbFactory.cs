using System;
using Covid19.Morocco.Data;

namespace Covid19.Morocco.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        CoronaContext Init();
    }
}