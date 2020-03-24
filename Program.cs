using System;
using System.Collections.Generic;

namespace BookFinderApp
{
	public class Program
	{
		#region Public Methods

		public static void Main(string[] args)
		{
			DatabaseConnector connector = SetupConnection();
			bool stop = false;

			while (!stop) {
				// TODO: Implement flag to check connection should remain open
				List<Book> books = FindBooks(connector);
				stop = true;
			}

			connector.CloseConnection();
		}

		#endregion

		#region Private Static Methods

		private static DatabaseConnector SetupConnection()
		{
			DatabaseConnector connector = new DatabaseConnector();
			connector.OpenConnection();
			return connector;
		}

		private static List<Book> FindBooks(DatabaseConnector connector)
		{
			string searchTerm = ""; // Setup way of transferring term from React to here
			List<Book> books = RunSelectQuery(connector, searchTerm);
			return books;
		}

		private static List<Book> RunSelectQuery(DatabaseConnector connector, string searchTerm)
		{
			string sql = string.Format("SELECT * FROM [dbo].[book_list] WHERE [Title] LIKE '%{0}%' " +
				"OR [Author] LIKE '%{1}%' OR [Published Date] LIKE '%{2}%'", searchTerm);
			List <Book> books = connector.ExecuteQuery(sql);
			return books;
		}

		#endregion
	}
}