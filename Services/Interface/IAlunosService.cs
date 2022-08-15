using System.Collections.Generic;
using dema.back.ViewModels;

namespace dema.back.Services.Interface
{
    public interface IAlunosService
    {
        void Adicionar(AlunosViewModel alunoViewModel);
        void Alterar(AlunosViewModel alunoViewModel);
        void Remover(AlunosViewModel alunoViewModel);
        IEnumerable<AlunosViewModel> Listar();
        AlunosViewModel ObterPorId(int id);

    }
}