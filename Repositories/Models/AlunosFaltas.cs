using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dema.back.Repositories.Models
{
    public class AlunosFaltas
    {
        public int Id { get; set; }
        public string AlunosId { get; set; }
        public string CursosId { get; set; }
    }
}