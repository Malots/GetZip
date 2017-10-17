using GetZip.ValueObject;
using System.Threading.Tasks;

namespace GetZip.Interfaces
{
    /// <summary>
    /// Interface to abstract base service
    /// </summary>
    public interface ISearch
    {
        Task<bool> IsOnline();
        Task<Address> GetAddress(string zipCode);
    }
}
