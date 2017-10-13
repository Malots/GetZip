using GetZip.ValueObject;
using System.Threading.Tasks;

namespace GetZip.Interfaces
{
    public interface ISearch
    {
        Task<bool> IsOnline();
        Task<Address> GetAddress(string zipCode);
    }
}
