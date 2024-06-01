using System;
using System.Transactions;

namespace PhoneBookApp.DataAccessLayer.Core
{
    public class UnitOfWork
    {
        private readonly PhoneBookEntities _context;
        public UnitOfWork(PhoneBookEntities context)
        {
            _context = context;
        }
        public int Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    
                    var retValu = _context.SaveChanges();
                    scope.Complete();
                    return retValu;
                }
                catch (Exception )
                {
                    scope.Dispose();
                    return 0;
                }
            }
        }
    }
}
