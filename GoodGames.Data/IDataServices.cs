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
        public User GetUser(int id);

        [OperationContract]
        public User GetUserByUsername(string username);

        [OperationContract]
        public User GetUserByEmail(string email);

        [OperationContract]
        public Game[] GetGamesForUser(int userId);

        [OperationContract]
        public double GetGameMedia(int gameId);

        [OperationContract]
        public Game ChangeGameStatus(int gameId, int userId, GameStatus status);

        [OperationContract]
        public Game ChangeGameMark(int gameId, int userId, double newMark);

    }
}
