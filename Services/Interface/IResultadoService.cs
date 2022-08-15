using System.Collections.Generic;
using dema.back.ViewModels;

namespace dema.back.Services.Interface
{
    public interface IResultadoService
    {
        IEnumerable<ResultadoViewModel> ObterPorAlunoId(int alunoId);
    }
}