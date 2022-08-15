using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories.Models;

namespace dema.back.Repositories.Interface
{
    public interface ICursosRepository
    {
        void Adicionar(Cursos curso);
        void Alterar(Cursos curso);
        void Remover(Cursos curso);
        IEnumerable<Cursos> Listar();
        Cursos ObterPorId(int id);
        IEnumerable<Cursos> ObterPorAlunoId(int alunoId);
    }
}