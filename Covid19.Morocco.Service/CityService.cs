using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Infrastructure;
using Covid19.Morocco.Repository;

namespace Covid19.Morocco.Service
{
    public class CityService : ICityService
    {

        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public City Get(Guid id) => _cityRepository.Get(id);

        public void Add(City city) => _cityRepository.Add(city);

        public void Update(City city) => _cityRepository.Update(city);

        public void Delete(City city) => _cityRepository.Delete(city);

        public IEnumerable<City> GetAll() => (IEnumerable<City>)_cityRepository.GetAll();
        public IEnumerable<City> GetMany(Expression<Func<City, bool>> where) => (IEnumerable<City>)_cityRepository.GetMany(where);

        public void Save() => _unitOfWork.Commit();
    }
}