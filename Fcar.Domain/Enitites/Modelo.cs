using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcar.Domain.Enitites
{
    public class Modelo
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
