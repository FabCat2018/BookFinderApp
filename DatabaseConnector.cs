using System;
using System.Data.SqlClient;

namespace VideogameDatabaseSystem.DatabaseSystem
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

		public void ExecuteQuery(string sqlToExecute)
		{
			SqlCommand command = new SqlCommand(sqlToExecute, conn);

			if (sqlToExecute[0].Equals('S')) {
				using (SqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						Console.WriteLine(string.Format("| {0} \t | {1} \t | {2} \t | {3}",
							reader[0], reader[1], reader[2], reader[3]));
					}
				}
			} else {
				command.ExecuteNonQuery();
			}
		}

		public void CloseConnection()
		{
			conn.Close();
			Console.WriteLine("Connection Closed");
			conn.Dispose();
			Console.WriteLine("Connection Disposed");
		}

		#endregion
	}
}