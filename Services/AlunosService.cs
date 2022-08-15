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
    public class AlunosService : IAlunosService
    {
        private readonly IAlunosRepository _alunosRepository;
        private readonly ICursosService _cursosService;
        private readonly IMapper _mapper;
        public AlunosService(IAlunosRepository alunosRepository, IMapper mapper,
        ICursosService cursosService)
        {
            _alunosRepository = alunosRepository;
            _cursosService = cursosService;
            _mapper = mapper;
        }

        public void Adicionar(AlunosViewModel alunoViewModel)
        {
            Alunos _alunos = _mapper.Map<Alunos>(alunoViewModel);
            _alunosRepository.Adicionar(_alunos);
        }

        public void Alterar(AlunosViewModel alunoViewModel)
        {
            Alunos _alunos = _mapper.Map<Alunos>(alunoViewModel);
            _alunosRepository.Alterar(_alunos);
        }

        public IEnumerable<AlunosViewModel> Listar()
        {
            List<AlunosViewModel> _alunosViewModel = new List<AlunosViewModel>();
            IEnumerable<Alunos> _alunos = _alunosRepository.Listar();

            _alunosViewModel = _mapper.Map<List<AlunosViewModel>>(_alunos);

            return _alunosViewModel;
        }

        public AlunosViewModel ObterPorId(int id)
        {
            AlunosViewModel _alunosViewModel = new AlunosViewModel();
            Alunos _alunos = _alunosRepository.ObterPorId(id);

            _alunosViewModel = _mapper.Map<AlunosViewModel>(_alunos);

            if (_alunosViewModel == null)
                return null;

            _alunosViewModel.Cursos = _mapper.Map<List<CursosViewModel>>(_cursosService.ObterPorAlunoId(_alunosViewModel.Id));

            return _alunosViewModel;
        }

        public void Remover(AlunosViewModel alunoViewModel)
        {
            Alunos _alunos = _mapper.Map<Alunos>(alunoViewModel);
            _alunosRepository.Remover(_alunos);
        }
    }
}