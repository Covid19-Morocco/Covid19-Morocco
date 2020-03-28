using System;
using System.Collections.Generic;
using Covid19.Morocco.Data.Models;
using Covid19.Morocco.Infrastructure;
using Covid19.Morocco.Repository;

namespace Covid19.Morocco.Service
{
    public class CasesService : ICasesService
    {

        private readonly ICasesRepository _casesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CasesService(ICasesRepository casesRepository, IUnitOfWork unitOfWork)
        {
            _casesRepository = casesRepository;
            _unitOfWork = unitOfWork;
        }

        public Cases Get(Guid id) => _casesRepository.Get(id);

        public void Add(Cases cases) => _casesRepository.Add(cases);

        public void Update(Cases cases) => _casesRepository.Update(cases);

        public void Delete(Cases cases) => _casesRepository.Delete(cases);

        public IEnumerable<Cases> GetAll() => (IEnumerable<Cases>) _casesRepository.GetAll();

        public void Save() => _unitOfWork.Commit();
    }
}