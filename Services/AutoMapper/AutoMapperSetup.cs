using AutoMapper;
using dema.back.Repositories.Models;
using dema.back.ViewModels;

namespace dema.back.Services.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region "ViewModelToDomain"
            CreateMap<AlunosFaltasViewModel, AlunosFaltas>();
            CreateMap<AlunosCursosViewModel, AlunosCursos>();
            CreateMap<AlunosViewModel, Alunos>();
            CreateMap<CriteriosViewModel, Criterios>();
            CreateMap<CursosAvaliacoesViewModel, CursosAvaliacoes>();
            CreateMap<CursosViewModel, Cursos>();
            CreateMap<ResultadoViewModel, Resultado>();
            #endregion

            #region "DomainToViewModel"
            CreateMap<AlunosFaltas, AlunosFaltasViewModel>();
            CreateMap<AlunosCursos, AlunosCursosViewModel>();
            CreateMap<Alunos, AlunosViewModel>();
            CreateMap<Criterios, CriteriosViewModel>();
            CreateMap<CursosAvaliacoes, CursosAvaliacoesViewModel>();
            CreateMap<Cursos, CursosViewModel>();
            CreateMap<Resultado, ResultadoViewModel>();
            #endregion
        }
    }
}