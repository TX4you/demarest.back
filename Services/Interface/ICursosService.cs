using System.Collections.Generic;
using dema.back.ViewModels;

namespace dema.back.Services.Interface
{
    public interface ICursosService
    {
        void Adicionar(CursosViewModel cursoViewModel);
        void Alterar(CursosViewModel cursoViewModel);
        void Remover(CursosViewModel cursoViewModel);
        IEnumerable<CursosViewModel> Listar();
        CursosViewModel ObterPorId(int id);
        IEnumerable<CursosViewModel> ObterPorAlunoId(int alunoId);
    }
}