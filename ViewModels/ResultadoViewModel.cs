using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dema.back.ViewModels
{
    public class ResultadoViewModel
    {
        public string Aluno { get; set; }
        public string Curso { get; set; }
        public string Avaliacoes { get; set; }
        public string FrequenciaMinima { get; set; }
        public string QuantidadeAulas { get; set; }
        public string faltas { get; set; }
        public string Media { get; set; }
        public string CursosAvaliacoes { get; set; }
    }
}