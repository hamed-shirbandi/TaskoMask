
namespace TaskoMask.Domain.Core.Services
{
    public interface IEncryptionService
    {
        string CreateSaltKey(int size);
        string CreatePasswordHash(string password, string saltkey);
        string EncryptText(string plainText, string privateKey);
        string DecryptText(string cipherText, string encryptionPrivateKey);
    }
}
