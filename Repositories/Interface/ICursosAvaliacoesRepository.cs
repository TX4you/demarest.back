using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories.Models;

namespace dema.back.Repositories.Interface
{
    public interface ICursosAvaliacoesRepository
    {
        void Adicionar(CursosAvaliacoes cursoAvaliacao);
        IEnumerable<CursosAvaliacoes> Listar();
        IEnumerable<CursosAvaliacoes>  ObterPorAlunoId(int alunoId);
        IEnumerable<CursosAvaliacoes>  ObterPorCursoId(int cursoId);
        IEnumerable<CursosAvaliacoes>  ObterPorAlunoIdCursoId(int alunoId, int cursoId);
        
    }
}