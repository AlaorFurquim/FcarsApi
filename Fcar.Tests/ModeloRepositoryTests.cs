using Fcar.Domain.Enitites;
using Fcar.Infrastructure;
using Fcar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcar.Tests
{
    public class ModeloRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public ModeloRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
        }

        [Fact]
        public async Task DeveAdicionarMarca()
        {
            using var context = new AppDbContext(_options);
            var repo = new ModeloRepository(context);

            var marca = new Marca("Volkswagen");

            await repo.AddAsync(marca);
            var marcas = await repo.GetAllAsync();

            Assert.Single(marcas);
            Assert.Equal("Volkswagen", marcas.First().Name);
        }

        [Fact]
        public async Task DeveAdicionarModelo()
        {
            using var dbContext = new AppDbContext(_options);
            var marca = new Marca("Honda");
            dbContext.Marcas.Add(marca);
            await dbContext.SaveChangesAsync();

            var modelo = new Modelo("Civic", "Sedan compacto", marca.Id);
            dbContext.Modelos.Add(modelo);
            await dbContext.SaveChangesAsync();

            var modelos = dbContext.Modelos.ToList();

            Assert.Single(modelos);
            Assert.Equal("Civic", modelos.First().Name);
                
        }
    }
}
