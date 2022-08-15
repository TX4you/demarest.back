using System.Collections.Generic;
using dema.back.ViewModels;

namespace dema.back.Services.Interface
{
    public interface IAlunosFaltasService
    {
        void Adicionar(AlunosFaltasViewModel alunoFaltaViewModel);
        IEnumerable<AlunosFaltasViewModel> Listar();
        IEnumerable<AlunosFaltasViewModel> ObterPorAlunoId(int alunoId);
        IEnumerable<AlunosFaltasViewModel> ObterPorCursoId(int cursoId);
        IEnumerable<AlunosFaltasViewModel> ObterPorAlunoIdCursoId(int alunoId, int cursoId);

    }
}