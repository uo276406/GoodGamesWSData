using GoodGames.Data.Model;
using System.Media;
using System.ServiceModel;
using System.Xml.Linq;

namespace GoodGames.Data
{
    public class DataServices : IDataServices
    {
        public User CreateUser(string username, string password, string email)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                if (factory.UserDAO.All().Any(user => user.Username.ToLower().Equals(username.ToLower())))
                {
                    throw new FaultException(new FaultReason("Usernam exists in database"), new FaultCode("400"), "");
                }

                if (factory.UserDAO.All().Any(user => user.Email.ToLower().Equals(email.ToLower())))
                {
                    throw new FaultException(new FaultReason("Email exists in database"), new FaultCode("400"), "");
                }

                User newUser = new User();
                newUser.Username = username;
                newUser.Password = password;
                newUser.Email = email;

                factory.UserDAO.Add(newUser);
                return newUser;
            }
        }


        public double GetGameMedia(int id)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                Game[] game = factory.GameDAO.All().Where((game) => game.Id == id && game.Status.Equals(GameStatus.FINISHED) && game.Mark != -1).ToArray();
                int numberOfMarks = game.Length;

                double total = game.Sum((game) => game.Mark);

                return total / numberOfMarks;

            }
        }


        public Game[] GetGamesForUser(string username)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.GameDAO.All().Where((game) => game.Player.Username.ToLower().Equals(username.ToLower())).ToArray();
            }
        }

        public User? GetUser(int id)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.UserDAO.Find(id);
            }
        }

        public User? GetUserByEmail(string email)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.UserDAO.All().FirstOrDefault((user) => user.Email.ToLower().Equals(email.ToLower()));
            }
        }

        public User? GetUserByUsername(string username)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.UserDAO.All().FirstOrDefault((user) => user.Username.ToLower().Equals(username.ToLower()));
            }
        }

        public Game ChangeGameStatus(int id, int userId, GameStatus status)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                Game gameFound = factory.GameDAO.All().Where((game) => game.Id == id && game.Player.Id == userId).First();

                if (gameFound != null)
                {
                    gameFound.Status = status;
                    factory.GameDAO.Update(gameFound);
                    return gameFound;
                }
                else
                {
                    User playerRelated = factory.UserDAO.Find(userId);
                    Game toAdd = new Game();
                    toAdd.Id = id;
                    toAdd.Mark = -1;
                    toAdd.Status = status;
                    toAdd.Player = playerRelated;
                    factory.GameDAO.Add(toAdd);
                    return toAdd;
                }
            }
        }

        public Game ChangeGameMark(int id, int userId, double newMark)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                Game gameFound = factory.GameDAO.All().Where((game) => game.Id == id && game.Player.Id == userId).First();

                if (gameFound != null)
                {
                    gameFound.Mark = newMark;
                    factory.GameDAO.Update(gameFound);
                    return gameFound;
                }
                else
                {
                    throw new FaultException(new FaultReason("Game not found for user"), new FaultCode("400"), "");
                }
            }
        }
    }
}
