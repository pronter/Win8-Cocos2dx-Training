using System.Threading.Tasks;

namespace mvvmTest.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}