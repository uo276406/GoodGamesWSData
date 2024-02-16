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
        public Game[] GetGamesById(int gameId);

        [OperationContract]
        public Game UpdateGame(int gameId, int userId, GameStatus newStatus, double newMark, String newReview);

        [OperationContract]
        public Game AddGameToUser(int gameId, int userId);

    }
}
