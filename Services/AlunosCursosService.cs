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
    public class AlunosCursosService : IAlunosCursosService
    {
        private readonly IAlunosCursosRepository _alunosCursosRepository;
        private readonly IMapper _mapper;
        public AlunosCursosService(IAlunosCursosRepository alunosCursosRepository, IMapper mapper)
        {
            _alunosCursosRepository = alunosCursosRepository;
            _mapper = mapper;
        }
        public void Adicionar(AlunosCursosViewModel alunoCursosViewModel)
        {
            AlunosCursos _alunosCursos = _mapper.Map<AlunosCursos>(alunoCursosViewModel);
            _alunosCursosRepository.Adicionar(_alunosCursos);
        }

        public AlunosCursosViewModel ObterPorAlunoIdCursoId(int alunoId, int cursoId)
        {
            AlunosCursosViewModel _alunosCursosViewModel = new AlunosCursosViewModel();
            AlunosCursos _alunosCursos = _alunosCursosRepository.ObterPorAlunoIdCursoId(alunoId, cursoId);

            _alunosCursosViewModel = _mapper.Map<AlunosCursosViewModel>(_alunosCursos);

            return _alunosCursosViewModel;
        }

        public AlunosCursosViewModel ObterPorId(int id)
        {
             AlunosCursosViewModel _alunosCursosViewModel = new AlunosCursosViewModel();
            AlunosCursos _alunosCursos = _alunosCursosRepository.ObterPorId(id);

            _alunosCursosViewModel = _mapper.Map<AlunosCursosViewModel>(_alunosCursos);

            return _alunosCursosViewModel;
        }
    }
}