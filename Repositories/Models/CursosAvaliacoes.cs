using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dema.back.Repositories.Models
{
    public class CursosAvaliacoes
    {
        public int Id { get; set; }
        public string CursosId { get; set; }
        public string AlunosId { get; set; }
        public string Nota { get; set; }
    }
}