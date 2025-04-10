using Fcar.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcar.Tests
{
    public class ModeloTests
    {
        [Fact]
        public void DeveCriarModeloValido()
        {
            var modelo = new Modelo("Corolla", "Sedan médio", 1);

            Assert.Equal("Corolla", modelo.Name);
            Assert.Equal("Sedan médio", modelo.Description);
            Assert.Equal(1, modelo.MarcaId);
        }

        [Theory]
        [InlineData(null, "desc")]
        [InlineData("ok", null)]
        [InlineData("a", "desc")]
        [InlineData("ok", "a")]
        public void DeveFalharComDadosInvalidos(string name, string desc)
        {
            Assert.ThrowsAny<Exception>(() => new Modelo(name, desc, 1));
        }

        [Fact]
        public void DeveFalharComMarcaIdNegativo()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Modelo("Corolla", "desc", -1));
            Assert.Contains("marcaId", ex.Message);
        }
    }
}
