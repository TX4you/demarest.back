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
    public class CursosAvaliacoesService : ICursosAvaliacoesService
    {
        private readonly ICursosAvaliacoesRepository _cursosAvaliacoesRepository;
        private readonly IMapper _mapper;
        public CursosAvaliacoesService(ICursosAvaliacoesRepository cursosAvaliacoesRepository, IMapper mapper)
        {
            _cursosAvaliacoesRepository = cursosAvaliacoesRepository;
            _mapper = mapper;
        }

        public void Adicionar(CursosAvaliacoesViewModel cursoAvaliacaoViewModel)
        {
            CursosAvaliacoes _cursosAvaliacoes = _mapper.Map<CursosAvaliacoes>(cursoAvaliacaoViewModel);
            _cursosAvaliacoesRepository.Adicionar(_cursosAvaliacoes);
        }

        public IEnumerable<CursosAvaliacoesViewModel> Listar()
        {
            List<CursosAvaliacoesViewModel> _cursosAvaliacoesViewModel = new List<CursosAvaliacoesViewModel>();
            IEnumerable<CursosAvaliacoes> _cursosAvaliacoes = _cursosAvaliacoesRepository.Listar();

            _cursosAvaliacoesViewModel = _mapper.Map<List<CursosAvaliacoesViewModel>>(_cursosAvaliacoes);

            return _cursosAvaliacoesViewModel;
        }

        public IEnumerable<CursosAvaliacoesViewModel> ObterPorAlunoId(int alunoId)
        {
            List<CursosAvaliacoesViewModel> _cursosAvaliacoesViewModel = new List<CursosAvaliacoesViewModel>();
            IEnumerable<CursosAvaliacoes> _cursosAvaliacoes = _cursosAvaliacoesRepository.ObterPorAlunoId(alunoId);

            _cursosAvaliacoesViewModel = _mapper.Map<List<CursosAvaliacoesViewModel>>(_cursosAvaliacoes);

            return _cursosAvaliacoesViewModel;

        }

        public IEnumerable<CursosAvaliacoesViewModel> ObterPorAlunoIdCursoId(int alunoId, int cursoId)
        {
            List<CursosAvaliacoesViewModel> _cursosAvaliacoesViewModel = new List<CursosAvaliacoesViewModel>();
            IEnumerable<CursosAvaliacoes> _cursosAvaliacoes = _cursosAvaliacoesRepository.ObterPorAlunoIdCursoId(alunoId, cursoId);

            _cursosAvaliacoesViewModel = _mapper.Map<List<CursosAvaliacoesViewModel>>(_cursosAvaliacoes);

            return _cursosAvaliacoesViewModel;
        }

        public IEnumerable<CursosAvaliacoesViewModel> ObterPorCursoId(int cursoId)
        {
            List<CursosAvaliacoesViewModel> _cursosAvaliacoesViewModel = new List<CursosAvaliacoesViewModel>();
            IEnumerable<CursosAvaliacoes> _cursosAvaliacoes = _cursosAvaliacoesRepository.ObterPorCursoId(cursoId);

            _cursosAvaliacoesViewModel = _mapper.Map<List<CursosAvaliacoesViewModel>>(_cursosAvaliacoes);

            return _cursosAvaliacoesViewModel;
        }
    }
}