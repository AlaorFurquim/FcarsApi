using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fcar.Domain.Enitites
{
    public class Modelo
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MarcaId { get; set; }

        public Modelo(string name,string description, int marcaId)
        {
            if(marcaId < 0)
                throw new ArgumentException("Invalid value for marcaId", nameof(marcaId));
            MarcaId = marcaId;

            ValidateDomain(name,description);
        }

        public Modelo(int id,string name, string description, int marcaId)
        {
            if (id < 0)
                throw new ArgumentException("Invalid value for Id", nameof(id));
            Id = id;
            if (marcaId < 0)
                throw new ArgumentException("Invalid value for marcaId", nameof(marcaId));
            MarcaId = marcaId;

            ValidateDomain(name, description);
        }

        private void ValidateDomain(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name is required");

            if (name.Length < 3)
                throw new ArgumentException("Name is too short, minimum 3 characters", nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description), "Description is required");

            if (description.Length < 3)
                throw new ArgumentException("Description is too short, minimum 3 characters", nameof(description));

            Name = name;
            Description = description;
        }
        public Marca Marca { get; set; }
    }
}
