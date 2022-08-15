using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories.Models;

namespace dema.back.Repositories.Interface
{
    public interface ICriteriosRepository
    {
        void Adicionar(Criterios criterio);
        void Alterar(Criterios criterio);
        void Remover(Criterios criterio);
        IEnumerable<Criterios> Listar();
        Criterios ObterPorId(int id);
    }
}