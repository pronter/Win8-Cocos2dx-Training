using System.Threading.Tasks;

namespace week4Search.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}