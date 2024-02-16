using GoodGames.Data.Model;
using System.Media;
using System.Net.NetworkInformation;
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
                    throw new FaultException(new FaultReason("Username exists in database"), new FaultCode("400"), "");
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


        public Game[] GetGamesForUser(int userId)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                User playerRelated = factory.UserDAO.Find(userId);
                return factory.GameDAO.All().Where((game) => game.Player != null && game.Player.Id == playerRelated.Id).ToArray();
            }
        }

        public Game[] GetGamesById(int gameId)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.GameDAO.All().Where((game) => game.GameId == gameId).ToArray();
            }
        }

        public User? GetUser(int userId)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                return factory.UserDAO.Find(userId);
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

        public Game UpdateGame(int gameId, int userId, GameStatus newStatus, double newMark, String newReview)
        {
            using (DAOFactory factory = new DAOFactory())
            {
                User playerRelated = factory.UserDAO.Find(userId);
                Game? gameFound = factory.GameDAO.All()
                    .FirstOrDefault(game => game != null && game.GameId == gameId && game.Player != null && game.Player.Equals(playerRelated));


                if (gameFound != null)
                {
                    gameFound.Status = newStatus;
                    gameFound.Mark = newMark;
                    gameFound.Review = newReview;
                    gameFound.LastUpdate = DateTime.Now;
                    factory.GameDAO.Update(gameFound);
                    return gameFound;
                }
                else
                {
                    throw new FaultException(new FaultReason("Game not found for user"), new FaultCode("400"), "");
                }
            }
        }

        public Game AddGameToUser(int gameId, int userId)
        {

            using (DAOFactory factory = new DAOFactory())
            {
                User playerRelated = factory.UserDAO.Find(userId);
                Game? gameFound = factory.GameDAO.All()
                    .FirstOrDefault(game => game != null && game.GameId == gameId && game.Player != null && game.Player.Equals(playerRelated));
                
                if (gameFound == null)
                {
                    Game toAdd = new()
                    {
                        GameId = gameId,
                        Mark = -1,
                        Status = GameStatus.WANT_PLAY,
                        Player = playerRelated,
                        Review = "",
                        LastUpdate = DateTime.Now,
                    };
                    factory.GameDAO.Add(toAdd);
                    return toAdd;
                }
                else
                {
                    throw new FaultException(new FaultReason("Game already exists for user"), new FaultCode("400"), "");
                }
            }
        }
    }
}
