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
    public class CursosService : ICursosService
    {
        private readonly ICursosRepository _cursosRepository;
        private readonly IMapper _mapper;
        public CursosService(ICursosRepository cursosRepository, IMapper mapper)
        {
            _cursosRepository = cursosRepository;
            _mapper = mapper;
        }
        public void Adicionar(CursosViewModel cursoViewModel)
        {
            Cursos _cursos = _mapper.Map<Cursos>(cursoViewModel);
            _cursosRepository.Adicionar(_cursos);
        }

        public void Alterar(CursosViewModel cursoViewModel)
        {
            Cursos _cursos = _mapper.Map<Cursos>(cursoViewModel);
            _cursosRepository.Alterar(_cursos);
        }

        public IEnumerable<CursosViewModel> Listar()
        {
            List<CursosViewModel> _cursosViewModel = new List<CursosViewModel>();
            IEnumerable<Cursos> _cursos = _cursosRepository.Listar();

            _cursosViewModel = _mapper.Map<List<CursosViewModel>>(_cursos);

            return _cursosViewModel;
        }

        public IEnumerable<CursosViewModel> ObterPorAlunoId(int alunoId)
        {
             List<CursosViewModel> _cursosViewModel = new List<CursosViewModel>();
            IEnumerable<Cursos> _cursos = _cursosRepository.ObterPorAlunoId(alunoId);

            _cursosViewModel = _mapper.Map<List<CursosViewModel>>(_cursos);

            return _cursosViewModel;
        }

        public CursosViewModel ObterPorId(int id)
        {
            CursosViewModel _cursosViewModel = new CursosViewModel();
            Cursos _cursos = _cursosRepository.ObterPorId(id);

            _cursosViewModel = _mapper.Map<CursosViewModel>(_cursos);

            return _cursosViewModel;
        }

        public void Remover(CursosViewModel cursoViewModel)
        {
            Cursos _cursos = _mapper.Map<Cursos>(cursoViewModel);
            _cursosRepository.Remover(_cursos);
        }
    }
}