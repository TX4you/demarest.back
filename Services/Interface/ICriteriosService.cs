using System.Collections.Generic;
using dema.back.ViewModels;

namespace dema.back.Services.Interface
{
    public interface ICriteriosService
    {
        void Adicionar(CriteriosViewModel criterioViewModel);
        void Alterar(CriteriosViewModel criterioViewModel);
        void Remover(CriteriosViewModel criterioViewModel);
        IEnumerable<CriteriosViewModel> Listar();
        CriteriosViewModel ObterPorId(int id);
    }
}