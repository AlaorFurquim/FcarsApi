using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fcar.Domain.Enitites
{
    public class Marca
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
