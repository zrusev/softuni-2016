namespace _09_Increase_Age
{
    using Configuration;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            string sqlCommand = @" CREATE OR ALTER PROCEDURE dbo.usp_GetOlder @id INT
                                    AS
                                    UPDATE Minions
                                       SET Age += 1
                                     WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(Connection.ConnectionStringWithDatabase))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.ExecuteNonQuery();
                }

                string execQuery = @"Exec dbo.usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(execQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                string selectQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                        }
                    }
                }
            }
        }
    }
}
