using System.Threading.Tasks;

namespace Org.Visiontech.Commons
{
    public interface ITokenService
    {
        Task<string> GetToken(string username, string password);
    }
}
