using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fcar.Domain.Enitites
{
    public sealed class Marca
    {
        public int Id { get; set; }

        public Marca(string name)
        {
            ValidateDomain(name);
        }

        public Marca(int id,string name)
        {

            if (id < 0)
                throw new ArgumentException("Invalid value Id");
            ValidateDomain(name);
            Id = id;
        }

        public string Name { get; set; }

        private void ValidateDomain(string name)
        {
            if(name == null)
                throw new ArgumentNullException(nameof(name),"Invalid name. Name is required");
            if (name.Length < 3)
                throw new ArgumentException("Name is too short. Minimum 3 characters required.", nameof(name));

            Name = name;
        }

        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
