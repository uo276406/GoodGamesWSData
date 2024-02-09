using System.ServiceModel;
using GoodGames.Data.Model;

namespace GoodGames.Data
{
    [ServiceContract(Namespace = "http://GoodGames/data/")]
    public interface IDataServices
    {
        [OperationContract]
        public Statistics[] GetStatistics();

        [OperationContract]
        public long GetProductStatistics(string name);

        [OperationContract]
        public void CreateProductStatistics(string name);

        [OperationContract]
        public void UpdateProductStatistics(string name);
    }
}
