using System.Collections.Generic;
using dema.back.ViewModels;

namespace dema.back.Services.Interface
{
    public interface IAlunosCursosService
    {
        void Adicionar(AlunosCursosViewModel alunoCursosViewModel);
        AlunosCursosViewModel ObterPorId(int id);
        AlunosCursosViewModel ObterPorAlunoIdCursoId(int alunoId, int cursoId);
    }
}