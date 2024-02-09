using GoodGames.Data.Model;

namespace GoodGames.Data
{
    public class DataServices : IDataServices
    {
        public void CreateProductStatistics(string name)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                var statistic = factory.StatisticsDAO.All().FirstOrDefault(statistic => statistic.ProductName.ToLower().Equals(name.ToLower()));

                if(statistic != null)
                {
                    // thorw fault
                }

                Statistics newStatistic = new Statistics();
                newStatistic.ProductName = name;
                factory.StatisticsDAO.Add(newStatistic);
            }
        }

        public long GetProductStatistics(string name)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.StatisticsDAO.All().FirstOrDefault(statistic => statistic.ProductName.ToLower().Equals(name.ToLower())).Visits;
            }
        }

        public Statistics[] GetStatistics()
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.StatisticsDAO.All().ToArray();
            }
        }

        public void UpdateProductStatistics(string name)
        {
            throw new NotImplementedException();
        }
    }
}
