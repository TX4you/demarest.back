using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories.Models;

namespace dema.back.Repositories.Interface
{
    public interface IAlunosFaltasRepository
    {
        void Adicionar(AlunosFaltas alunoFalta);
        IEnumerable<AlunosFaltas> Listar();
        IEnumerable<AlunosFaltas> ObterPorAlunoId(int alunoId);
        IEnumerable<AlunosFaltas> ObterPorCursoId(int cursoId);
        IEnumerable<AlunosFaltas> ObterPorAlunoIdCursoId(int alunoId, int cursoId);

    }
}