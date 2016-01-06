using System.Threading.Tasks;
using Homework_04.Model;

namespace Homework_04.Design
{
    public class DesignDataService : IDataService
    {
        public Task<DataItem> GetData()
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            return Task.FromResult(item);
        }
    }
}