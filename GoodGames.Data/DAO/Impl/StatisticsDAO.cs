using GoodGames.Data.Model;

namespace GoodGames.Data.DAO.Impl
{
    public class StatisticsDAO : GenericDAO<Statistics>, IStatisticsDAO
    {
        public StatisticsDAO(DataContext context) : base(context)
        {
        }
    }
}
