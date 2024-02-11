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
        public Game[] GetGamesForUser(string username);

        [OperationContract]
        public double GetGameMedia(int id);

        [OperationContract]
        public Game ChangeGameStatus(int id, int userId, GameStatus status);

        [OperationContract]
        public Game ChangeGameMark(int id, int userId, double newMark);

    }
}
