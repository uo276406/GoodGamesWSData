using System.Collections.Generic;

namespace GoodGames.Data.DAO
{
    public interface IGenericDAO<T> where T:class
    {
        bool Add(T t);
        bool Remove(T t);
        bool Update(T t);
        T Find(int id);
        IEnumerable<T> All();
        int Count();
    }
}
