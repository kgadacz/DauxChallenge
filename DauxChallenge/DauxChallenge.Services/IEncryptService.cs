namespace DauxChallenge.Services
{
    public interface IEncryptService
    {
        Task<string> EncryptApiAsync(string nombre, string apellido);
    }
}
