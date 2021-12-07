using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        protected override Product AddCore ( Product product )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("AddProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@IsDiscontinued", product.IsDiscontinued);

                object result = command.ExecuteScalar();
                product.Id = Convert.ToInt32(result);
            };

            return product;
        }
        protected override Product FindByName ( string name ) => throw new NotImplementedException();
        protected override IEnumerable<Product> GetAllCore ()
        {
            var dataSet = new DataSet();

            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("GetAllProducts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
            };

            var table = dataSet.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Id = Convert.ToInt32(row[0]),
                        Name = Convert.ToString(row[1]),
                        Price = Convert.ToDecimal(row[2]),
                        Description = row.IsNull(3) ? "" : row.Field<string>(3),
                        IsDiscontinued = Convert.ToBoolean(row[4])
                    };
                }
            }
        }
        protected override Product GetCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("GetProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product() {
                            Id = Convert.ToInt32(reader[0]),
                            Name = Convert.ToString(reader[1]),
                            Price = Convert.ToDecimal(reader[2]),
                            Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            IsDiscontinued = Convert.ToBoolean(reader[4])
                        };
                    }
                }
            }

            return null;
        }
        protected override void RemoveCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("RemoveProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            };
        }
        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("UpdateProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", existing.Id);

                command.Parameters.AddWithValue("@name", newItem.Name);
                command.Parameters.AddWithValue("@price", newItem.Price);
                command.Parameters.AddWithValue("@description", newItem.Description);
                command.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

                command.ExecuteNonQuery();
            };

            return existing;
        }
    
        private SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
