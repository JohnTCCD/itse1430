using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MovieLibrary;

namespace MovieLibrarySql
{
    /// <summary> </summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override Movie AddCore ( Movie movie )
        {
            var conn = OpenConnection();

            var cmd = new SqlCommand("AddMovie", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Add parameters
            var paraName = new SqlParameter("@name", System.Data.SqlDbType.VarChar) {
                Value = movie.Title
            };
            cmd.Parameters.Add(paraName);

            //Approach2
            var parmRating = cmd.CreateParameter();
            parmRating.ParameterName = "@rating";
            parmRating.SqlDbType = System.Data.SqlDbType.VarChar;
            parmRating.Value = movie.Rating;
            cmd.Parameters.Add(parmRating);

            //Approach3 (SQL Server)
            cmd.Parameters.AddWithValue("@description", movie.Description);
            cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
            cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
            cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

            object result = cmd.ExecuteScalar();

            return movie;
        }
        protected override void DeleteCore ( int id ) => throw new NotImplementedException();
        protected override Movie FindById ( int id ) => throw new NotImplementedException();
        protected override Movie FindByTitle ( string title ) => null;
        protected override IEnumerable<Movie> GetAllCore () => throw new NotImplementedException();
        protected override Movie GetCore ( int id ) => throw new NotImplementedException();
        protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
    }
}
