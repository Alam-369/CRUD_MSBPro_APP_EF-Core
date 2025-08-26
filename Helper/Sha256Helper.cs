using System.Security.Cryptography;
using System.Text;

namespace MSBProCrudApp.Helper;

public interface ISha256Helper
{
    Task<string> Sha256HexAsync(string input);
    Task<bool> VerifySha256Async(string input, string expectedHex);
}

public class Sha256Helper : ISha256Helper
{
    private const string _surfixString = "MsbProApp";
   public async Task<string> Sha256HexAsync(string input)
    {
        return await Task.Run(() =>
        {
            var bytes = Encoding.UTF8.GetBytes($"{input}-{_surfixString}");
            var hash = SHA256.HashData(bytes);
            return Convert.ToHexString(hash);
        });
    }

    public async Task<bool> VerifySha256Async(string input, string expectedHex)
    {
        var actual = await Sha256HexAsync(input);
        return CryptographicOperations.FixedTimeEquals(
            Convert.FromHexString(actual),
            Convert.FromHexString(expectedHex));
    }
}