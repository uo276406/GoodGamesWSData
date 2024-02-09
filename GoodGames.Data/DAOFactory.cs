using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoodGames.Data.DAO;
using GoodGames.Data.DAO.Impl;

namespace GoodGames.Data
{
    public class DAOFactory : IDisposable
    {
        private DataContext _context;

        public DAOFactory()
        {
            _context = new DataContext();
        }

        public IStatisticsDAO StatisticsDAO
        {
            get { return new StatisticsDAO(_context); }
        }

        
        public void Dispose() { _context.Dispose(); }
    }
}