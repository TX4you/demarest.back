using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dema.back.ViewModels
{
    public class CriteriosViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string ValorMinimo { get; set; }
        public string ValorMaximo { get; set; }
    }
}