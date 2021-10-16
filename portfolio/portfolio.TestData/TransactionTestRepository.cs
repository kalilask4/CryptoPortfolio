using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace portfolio.TestData
{
    public class TransactionTestRepository : IRepository<Transaction>
    {
        public void Create(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Transaction> Find(Expression<Func<Transaction, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Transaction Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
