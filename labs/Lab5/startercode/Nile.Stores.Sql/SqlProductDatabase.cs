using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase( string connectionString )
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        protected override Product AddCore ( Product product ) => throw new NotImplementedException();
        protected override Product FindByName ( string name ) => throw new NotImplementedException();
        protected override IEnumerable<Product> GetAllCore () => throw new NotImplementedException();
        protected override Product GetCore ( int id ) => throw new NotImplementedException();
        protected override void RemoveCore ( int id ) => throw new NotImplementedException();
        protected override Product UpdateCore ( Product existing, Product newItem ) => throw new NotImplementedException();
    }
}
