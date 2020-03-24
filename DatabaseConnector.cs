using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookFinderApp
{
	public class DatabaseConnector
	{
		#region Private Fields

		private static SqlConnection conn;

		#endregion

		#region Public Constructors

		public DatabaseConnector()
		{
			conn = new SqlConnection(
				"Server=DESKTOP-U3ATH6F; Database=Books; Trusted_Connection=true"
			);
		}

		#endregion

		#region Public Methods

		public void OpenConnection()
		{
			conn.Open();
			Console.WriteLine("Connection Successful");
		}

		public List<Book> ExecuteQuery(string sqlToExecute)
		{
			SqlCommand command = new SqlCommand(sqlToExecute, conn);
			List<Book> books = new List<Book>();

			using (SqlDataReader reader = command.ExecuteReader()) {
				while (reader.Read()) {
					books.Add(CreateBook(reader));
				}
			}

			return books;
		}

		public void CloseConnection()
		{
			conn.Close();
			Console.WriteLine("Connection Closed");
			conn.Dispose();
			Console.WriteLine("Connection Disposed");
		}

		#endregion

		#region Private Helper Functions

		private static Book CreateBook(SqlDataReader reader)
		{
			string title = reader[0].ToString();
			string author = reader[1].ToString();
			DateTime publishedDate = (DateTime) reader[2];
			string imagePath = reader[3].ToString();

			return new Book(title, author, publishedDate, imagePath);
		}

		#endregion
	}
}