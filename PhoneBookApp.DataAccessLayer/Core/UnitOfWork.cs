using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.DataAccessLayer.Core
{
    public class UnitOfWork
    {
        private readonly PhoneBookEntities _context;
        public UnitOfWork()
        {
            _context = new PhoneBookEntities();
        }
        public int Save()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    
                    var retValu = _context.SaveChanges();
                    transaction.Commit();
                    return retValu;
                }
                catch (Exception )
                {
                    transaction.Dispose();
                    return 0;
                }
            }
        }
    }
}
