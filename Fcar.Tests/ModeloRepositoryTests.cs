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
        public async Task DeveAdicionarCliente()
        {
            using var context = new AppDbContext(_options);
            var repo = new ModeloRepository(context);

            var marca = new Marca { Name = "Teste" };

            await repo.AddAsync(marca);
            var marcas = await repo.GetAllAsync();

            Assert.Single(marcas);
            Assert.Equal("Teste", marcas.First().Name);
        }
    }
}
