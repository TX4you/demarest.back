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
    public class ResultadoService : IResultadoService
    {
        private readonly IResultadoRepository _resultadoRepository;
        private readonly IMapper _mapper;
        public ResultadoService(IResultadoRepository resultadoRepository, IMapper mapper)
        {
            _resultadoRepository = resultadoRepository;
            _mapper = mapper;
        }

        public IEnumerable<ResultadoViewModel> ObterPorAlunoId(int alunoId)
        {
            List<ResultadoViewModel> _resultadoViewModel = new List<ResultadoViewModel>();
            IEnumerable<Resultado> _resultado = _resultadoRepository.ObterPorAlunoId(alunoId);

            _resultadoViewModel = _mapper.Map<List<ResultadoViewModel>>(_resultado);

            return _resultadoViewModel;
        }
 
    }
}