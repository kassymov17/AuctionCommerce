
namespace AC.Services.Security
{
    public interface IEncryptionService
    {
        string CreateSaltKey(int size);

        string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1");

        string CreateHash(byte[] data, string hashAlgorithm = "SHA1");
    }
}
