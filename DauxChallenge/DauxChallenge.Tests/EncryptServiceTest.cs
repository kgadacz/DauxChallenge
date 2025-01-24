using DauxChallenge.Services;

namespace DauxChallenge.Tests
{
    public class EncryptServiceTests
    {
        [Fact]
        public async Task EncryptApiAsync_WithValidNombreAndApellido_ShouldReturnOkResult()
        {
            // Arrange
            var httpClient = new HttpClient();
            var encryptService = new EncryptService(httpClient);
            var nombre = "Kevin";
            var apellido = "Gadacz";

            // Act
            var result = await encryptService.EncryptApiAsync(nombre, apellido);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("{\"result\":\"OK\"}", result);
        }

        [Fact]
        public async Task EncryptApiAsync_WithEmptyNombreAndApellido_ShouldReturnHeaderMissingResult()
        {
            // Arrange
            var httpClient = new HttpClient();
            var encryptService = new EncryptService(httpClient);
            var nombre = "";
            var apellido = "";

            // Act
            var result = await encryptService.EncryptApiAsync(nombre, apellido);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("{\"result\":\"HEADER MISSING\"}", result);
        }
    }
}