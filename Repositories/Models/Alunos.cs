using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dema.back.Repositories.Models
{
    public class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
    }
}