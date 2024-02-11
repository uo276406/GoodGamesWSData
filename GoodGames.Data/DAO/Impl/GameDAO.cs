using GoodGames.Data.Model;

namespace GoodGames.Data.DAO.Impl
{
    public class GameDAO : GenericDAO<Game>, IGameDAO
    {
        public GameDAO(DataContext context) : base(context)
        {
        }
    }
}
