using System.Threading.Tasks;

namespace GetZip
{
    internal interface ICepSearch
    {
        Task<bool> IsOnline();
        Task<Address> GetByZip(string zipCode);
    }
}
