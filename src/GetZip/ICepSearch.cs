using GetZip.ValueObject;
using System.Threading.Tasks;

namespace GetZip
{
    public interface ICepSearch
    {
        Task<bool> IsOnline();
        Task<Address> GetByZip(string zipCode);
    }
}
