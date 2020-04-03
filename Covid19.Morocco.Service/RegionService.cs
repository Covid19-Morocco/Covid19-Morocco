using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Infrastructure;
using Covid19.Morocco.Repository;

namespace Covid19.Morocco.Service
{
    public class RegionService : IRegionService
    {

        private readonly IRegionRepository _regionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegionService(IRegionRepository regionRepository, IUnitOfWork unitOfWork)
        {
            _regionRepository = regionRepository;
            _unitOfWork = unitOfWork;
        }

        public Region Get(Guid id) => _regionRepository.Get(id);

        public void Add(Region region) => _regionRepository.Add(region);

        public void Update(Region region) => _regionRepository.Update(region);
        public void Delete(Region region) => _regionRepository.Delete(region);

        public IEnumerable<Region> GetAll() => (IEnumerable<Region>) _regionRepository.GetAll();
        public IEnumerable<Region> GetMany(Expression<Func<Region, bool>> @where) => (IEnumerable<Region>)_regionRepository.GetMany(where);

        public void Save() => _unitOfWork.Commit();
    }
}