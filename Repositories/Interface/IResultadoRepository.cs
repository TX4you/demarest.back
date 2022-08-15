using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories.Models;

namespace dema.back.Repositories.Interface
{
    public interface IResultadoRepository
    {
        IEnumerable<Resultado> ObterPorAlunoId(int alunoId);
    }
}