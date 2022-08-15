using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories.Models;

namespace dema.back.Repositories.Interface
{
    public interface IAlunosCursosRepository
    {
        void Adicionar(AlunosCursos alunoCursos);
        AlunosCursos ObterPorId(int id);
        AlunosCursos ObterPorAlunoIdCursoId(int alunoId, int cursoId);
    }
}