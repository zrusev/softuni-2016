namespace _06_Remove_Villain
{
    using Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Connection.ConnectionStringWithDatabase))
            {
                connection.Open();

                string villainQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
                string villainName = String.Empty;

                using (SqlCommand command = new SqlCommand(villainQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                int affectedRows = DeleteMinionsVillainById(connection, id);

                DeleteVillainsById(connection, id);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }

        private static void DeleteVillainsById(SqlConnection connection, int id)
        {
            string deleteVillainQuery = @"DELETE FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                command.ExecuteNonQuery();
            }
        }

        private static int DeleteMinionsVillainById(SqlConnection connection, int id)
        {
            string deleteVillainQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                return command.ExecuteNonQuery();
            }
        }
    }
}
