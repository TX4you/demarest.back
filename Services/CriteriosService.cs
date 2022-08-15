using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dema.back.Repositories.Interface;
using dema.back.Repositories.Models;
using dema.back.Services.Interface;
using dema.back.ViewModels;

namespace dema.back.Services
{
    public class CriteriosService : ICriteriosService
    {
        private readonly ICriteriosRepository _criteriosRepository;
        private readonly IMapper _mapper;
        public CriteriosService(ICriteriosRepository criteriosRepository, IMapper mapper)
        {
            _criteriosRepository = criteriosRepository;
            _mapper = mapper;
        }
        public void Adicionar(CriteriosViewModel criterioViewModel)
        {
            Criterios _criterios = _mapper.Map<Criterios>(criterioViewModel);
            _criteriosRepository.Adicionar(_criterios);
        }

        public void Alterar(CriteriosViewModel criterioViewModel)
        {
            Criterios _criterios = _mapper.Map<Criterios>(criterioViewModel);
            _criteriosRepository.Alterar(_criterios);
        }

        public IEnumerable<CriteriosViewModel> Listar()
        {
            List<CriteriosViewModel> _criteriosViewModel = new List<CriteriosViewModel>();
            IEnumerable<Criterios> _criterios = _criteriosRepository.Listar();

            _criteriosViewModel = _mapper.Map<List<CriteriosViewModel>>(_criterios);

            return _criteriosViewModel;
        }

        public CriteriosViewModel ObterPorId(int id)
        {
            CriteriosViewModel _criteriosViewModel = new CriteriosViewModel();
            Criterios _criterios = _criteriosRepository.ObterPorId(id);

            _criteriosViewModel = _mapper.Map<CriteriosViewModel>(_criterios);

            return _criteriosViewModel;
        }

        public void Remover(CriteriosViewModel criterioViewModel)
        {
            Criterios _criterios = _mapper.Map<Criterios>(criterioViewModel);
            _criteriosRepository.Remover(_criterios);
        }
    }
}