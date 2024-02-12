using System.ServiceModel;
using GoodGames.Data.Model;

namespace GoodGames.Data
{
    [ServiceContract(Namespace = "http://GoodGames/data/")]
    public interface IDataServices
    {
        [OperationContract]
        public User CreateUser(string username, string password, string email);

        [OperationContract]
        public User GetUser(int userId);

        [OperationContract]
        public User GetUserByUsername(string username);

        [OperationContract]
        public User GetUserByEmail(string email);

        [OperationContract]
        public Game[] GetGamesForUser(int userId);

        [OperationContract]
        public Game UpdateGameStatus(int gameId, int userId, GameStatus status);

        [OperationContract]
        public Game UpdateGameMark(int gameId, int userId, double newMark);

        [OperationContract]
        public Game AddGameToUser(int gameId, int userId);

    }
}
