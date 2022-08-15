using System.Collections.Generic;
using dema.back.ViewModels;

namespace dema.back.Services.Interface
{
    public interface ICursosAvaliacoesService
    {
        void Adicionar(CursosAvaliacoesViewModel cursoAvaliacaoViewModel);
        IEnumerable<CursosAvaliacoesViewModel> Listar();
        IEnumerable<CursosAvaliacoesViewModel>  ObterPorAlunoId(int alunoId);
        IEnumerable<CursosAvaliacoesViewModel>  ObterPorCursoId(int cursoId);
        IEnumerable<CursosAvaliacoesViewModel>  ObterPorAlunoIdCursoId(int alunoId, int cursoId);
    }
}