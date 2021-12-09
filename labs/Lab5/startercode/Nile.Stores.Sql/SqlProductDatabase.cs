/*
 * ITSE 1430
 * Lab 5
 * John Butler
 * Fall 2021
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase( string connectionString )
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        /// <summary> Adds a product to the database. </summary>
        /// <param name="product"> Product to add. </param>
        /// <returns> Product added. </returns>
        protected override Product AddCore ( Product product )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("AddProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@IsDiscontinued", product.IsDiscontinued);

                object result = command.ExecuteScalar();
                product.Id = Convert.ToInt32(result);
            };

            return product;
        }

        /// <summary> Finds a product by its name. </summary>
        /// <param name="name"> String name. </param>
        /// <returns> Product with name, if any. </returns>
        protected override Product FindByName ( string name )
        {
            var products = GetAllCore();
            foreach (var product in products)
            {
                if (product.Name.CompareTo(name) == 0)
                    return product;
            }

            return null;
        }

        /// <summary> Gets all products in the database. </summary>
        /// <returns> IEnumerable products. </returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            var dataSet = new DataSet();

            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("GetAllProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
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

        /// <summary> Gets a product using its id. </summary>
        /// <param name="id"> Id of the product. </param>
        /// <returns> Product, if found. </returns>
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

        /// <summary> Removes a product from the database. </summary>
        /// <param name="id"> Id of the product to remove. </param>
        protected override void RemoveCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("RemoveProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            };
        }

        /// <summary> Updates a product. </summary>
        /// <param name="existing"> The product to update. </param>
        /// <param name="newItem"> The product with updated information. </param>
        /// <returns> Updated product. </returns>
        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("UpdateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", existing.Id);

                command.Parameters.AddWithValue("@name", newItem.Name);
                command.Parameters.AddWithValue("@price", newItem.Price);
                command.Parameters.AddWithValue("@description", newItem.Description);
                command.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

                command.ExecuteNonQuery();
            };

            return existing;
        }
    
        /// <summary> Opens a connection to the database. </summary>
        /// <returns> Open connection. </returns>
        private SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
