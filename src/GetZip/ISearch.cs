using GetZip.ValueObject;
using System.Threading.Tasks;

namespace GetZip
{
    public interface ISearch
    {
        Task<bool> IsOnline();
        Task<Address> GetAddress(string zipCode);
    }
}
