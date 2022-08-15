using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories.Models;

namespace dema.back.Repositories.Interface
{
    public interface IAlunosRepository
    {
        void Adicionar(Alunos aluno);
        void Alterar(Alunos aluno);
        void Remover(Alunos aluno);
        IEnumerable<Alunos> Listar();
        Alunos ObterPorId(int id);
    }
}