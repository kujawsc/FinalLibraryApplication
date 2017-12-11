using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FinalLibraryApplication
{
    public class FinalLibraryRepositorySQL : IFinalLibraryRepository
    {
        private IEnumerable<Library> _librarys = new List<Library>();

        public FinalLibraryRepositorySQL()
        {
            _librarys = ReadAllLibrarys();
        }

        private IEnumerable<Library> ReadAllLibrarys()
        {
            IList<Library> librarys = new List<Library>();

            string connString = GetConnectionString();
            string sqlCommandString = "SELECT * from LibraryApplication";

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Library library = new Library();
                                library.ID = Convert.ToInt32(reader["ID"]);
                                library.BookTitle = reader["BookTitle"].ToString();
                                library.Author = reader["Author"].ToString();
                                library.Genre = reader["Genre"].ToString();
                                library.Series = reader["Series"].ToString();
                                library.ISBN = reader["ISBN"].ToString();
                                librarys.Add(library);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }

            return librarys;
        }

        public Library SelectById(int Id)
        {
            return _librarys.Where(sr => sr.ID == Id).FirstOrDefault();
        }

        public List<Library> SelectAll()
        {
            return _librarys as List<Library>;
        }

        public void Insert(Library library)
        {
            string connString = GetConnectionString();

            var sb = new StringBuilder("INSERT INTO Librarys");
            sb.Append(" ([ID],[BookTitle],[Author],[Genre},[Series],[ISBN])");
            sb.Append(" Values (");
            sb.Append("'").Append(library.ID).Append("',");
            sb.Append("'").Append(library.BookTitle).Append("',");
            sb.Append("'").Append(library.Author).Append("',");
            sb.Append("'").Append(library.Genre).Append("',");
            sb.Append("'").Append(library.Series).Append("',");
            sb.Append("'").Append(library.ISBN).Append("')");
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.InsertCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.InsertCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        public void Delete(int ID)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("DELETE FROM Librarys");
            sb.Append(" WHERE ID = ").Append(ID);
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        public void Update(Library library)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("UPDATE Librarys SET ");
            sb.Append("BookTitle = '").Append(library.BookTitle).Append("',");
            sb.Append("Author = ").Append(library.Author).Append(",");
            sb.Append("Genre = ").Append(library.Genre).Append(",");
           sb.Append("Series = ").Append(library.Series).Append(",");
          sb.Append("ISBN = ").Append(library.ISBN).Append(",");
            sb.Append("WHERE ");
            sb.Append("ID = ").Append(library.ID);
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.UpdateCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.UpdateCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        private static string GetConnectionString()
        {
            string returnValue = null;   // Assume failure.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["FinalLibraryApplication"];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }
            return returnValue;
        }

        public void Dispose()
        {
            _librarys = null;
        }
    }
}