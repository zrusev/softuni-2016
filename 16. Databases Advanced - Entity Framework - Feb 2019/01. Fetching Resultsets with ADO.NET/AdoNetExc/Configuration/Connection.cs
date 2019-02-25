namespace Configuration
{    
    public static class Connection
    {
        public const string ConnectionStringNoDatabase = @"Data Source=(LocalDB)\LocalDB;Integrated Security=SSPI;";

        public const string ConnectionStringWithDatabase = @"Data Source=(LocalDB)\LocalDB;Database=MinionsDB;Integrated Security=SSPI;";
    }
}
