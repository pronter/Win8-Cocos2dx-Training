using System.Threading.Tasks;

namespace Homework_04.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}