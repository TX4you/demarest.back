using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dema.back.Repositories;
using dema.back.Repositories.Interface;
using dema.back.Services;
using dema.back.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace dema.back.Ioc
{
    public class SimpleInjectorConfig
    {
        public static void Configure(IServiceCollection services)
        {

            #region "Service"
            services.AddTransient<IAlunosFaltasService, AlunosFaltasService>();
            services.AddTransient<IAlunosCursosService, AlunosCursosService>();
            services.AddTransient<IAlunosService, AlunosService>();
            services.AddTransient<ICriteriosService, CriteriosService>();
            services.AddTransient<ICursosAvaliacoesService, CursosAvaliacoesService>();
            services.AddTransient<ICursosService, CursosService>();
            services.AddTransient<IResultadoService, ResultadoService>();


            #endregion

            #region "Repositories"
            services.AddTransient<IAlunosFaltasRepository, AlunosFaltasRepository>();
            services.AddTransient<IAlunosCursosRepository, AlunosCursosRepository>();
            services.AddTransient<IAlunosRepository, AlunosRepository>();
            services.AddTransient<ICriteriosRepository, CriteriosRepository>();
            services.AddTransient<ICursosAvaliacoesRepository, CursosAvaliacoesRepository>();
            services.AddTransient<ICursosRepository, CursosRepository>();
            services.AddTransient<IResultadoRepository, ResultadoRepository>();
            services.AddTransient<IHelp, Help>();
            #endregion
        }
    }
}