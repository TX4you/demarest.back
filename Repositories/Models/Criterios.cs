using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dema.back.Repositories.Models
{
    public class Criterios
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string ValorMinimo { get; set; }
        public string ValorMaximo { get; set; }
        
    }
}