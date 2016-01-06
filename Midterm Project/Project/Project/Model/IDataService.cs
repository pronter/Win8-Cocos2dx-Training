using System.Threading.Tasks;

namespace Project.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}