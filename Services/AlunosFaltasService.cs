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
    public class AlunosFaltasService : IAlunosFaltasService
    {
        private readonly IAlunosFaltasRepository _alunosFaltasRepository;
        private readonly ICursosService _cursosService;
        private readonly IAlunosService _alunosService;
        private readonly IMapper _mapper;
        public AlunosFaltasService(IAlunosFaltasRepository alunosFaltasRepository, ICursosService cursosService,
                                       IAlunosService alunosService, IMapper mapper)
        {
            _alunosFaltasRepository = alunosFaltasRepository;
            _cursosService = cursosService;
            _alunosService = alunosService;
            _mapper = mapper;
        }
        public void Adicionar(AlunosFaltasViewModel alunoFaltaViewModel)
        {
            AlunosFaltas _alunosFaltas = _mapper.Map<AlunosFaltas>(alunoFaltaViewModel);
            _alunosFaltasRepository.Adicionar(_alunosFaltas);
        }

        public IEnumerable<AlunosFaltasViewModel> Listar()
        {
            List<AlunosFaltasViewModel> _alunosFaltasViewModel = new List<AlunosFaltasViewModel>();
            IEnumerable<AlunosFaltas> _alunosFaltas = _alunosFaltasRepository.Listar();

            _alunosFaltasViewModel = _mapper.Map<List<AlunosFaltasViewModel>>(_alunosFaltas);

            return _alunosFaltasViewModel;
        }

        public IEnumerable<AlunosFaltasViewModel> ObterPorAlunoId(int alunoId)
        {
            List<AlunosFaltasViewModel> _alunosFaltasViewModel = new List<AlunosFaltasViewModel>();
            IEnumerable<AlunosFaltas> _alunosFaltas = _alunosFaltasRepository.ObterPorAlunoId(alunoId);

            _alunosFaltasViewModel = _mapper.Map<List<AlunosFaltasViewModel>>(_alunosFaltas);

            return _alunosFaltasViewModel;
        }

        public IEnumerable<AlunosFaltasViewModel> ObterPorAlunoIdCursoId(int alunoId, int cursoId)
        {
            List<AlunosFaltasViewModel> _alunosFaltasViewModel = new List<AlunosFaltasViewModel>();
            IEnumerable<AlunosFaltas> _alunosFaltas = _alunosFaltasRepository.ObterPorAlunoIdCursoId(alunoId, cursoId);

            _alunosFaltasViewModel = _mapper.Map<List<AlunosFaltasViewModel>>(_alunosFaltas);

            if (_alunosFaltasViewModel == null)
                return null;

            _alunosFaltasViewModel.ForEach(u => u.Curso = _mapper.Map<CursosViewModel>(_cursosService.ObterPorId(Convert.ToInt32(u.CursosId))));
            _alunosFaltasViewModel.ForEach(u => u.Aluno = _mapper.Map<AlunosViewModel>(_alunosService.ObterPorId(Convert.ToInt32(u.AlunosId))));

            return _alunosFaltasViewModel;
        }

        public IEnumerable<AlunosFaltasViewModel> ObterPorCursoId(int cursoId)
        {
            List<AlunosFaltasViewModel> _alunosFaltasViewModel = new List<AlunosFaltasViewModel>();
            IEnumerable<AlunosFaltas> _alunosFaltas = _alunosFaltasRepository.ObterPorCursoId(cursoId);

            _alunosFaltasViewModel = _mapper.Map<List<AlunosFaltasViewModel>>(_alunosFaltas);

            return _alunosFaltasViewModel;
        }
    }
}