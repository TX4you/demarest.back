using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dema.back.Repositories.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Exclusivo { get; set; }
        public string Avaliacoes { get; set; }
        public string FrequenciaMinima { get; set; }
        public string QuantidadeAulas { get; set; }

    }
}