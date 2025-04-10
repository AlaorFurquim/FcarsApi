
using Fcar.Domain.Enitites;

public class MarcaTests
{
    [Fact]
    public void DeveCriarMarcaComNomeValido()
    {
        var marca = new Marca("Toyota");

        Assert.Equal("Toyota", marca.Name);
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    public void DeveFalharComNomeInvalido(string nomeInvalido)
    {
        var ex = Assert.ThrowsAny<Exception>(() => new Marca(nomeInvalido));
        Assert.Contains("Name", ex.Message);
    }

    [Fact]
    public void DeveCriarMarcaComIdEValidar()
    {
        var marca = new Marca(1, "Chevrolet");

        Assert.Equal(1, marca.Id);
        Assert.Equal("Chevrolet", marca.Name);
    }

    [Fact]
    public void DeveFalharComIdNegativo()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Marca(-1, "Fiat"));
        Assert.Contains("Id", ex.Message);
    }
}

