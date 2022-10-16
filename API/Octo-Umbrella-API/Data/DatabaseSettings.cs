namespace Octo_Umbrella_API.Data
{
    public class DatabaseSettings
    {
        public static string ConnectionString { get;  } = "mongodb://dbUser:fKpYc4GozNGC3aN0@cluster0-shard-00-00.9jh3r.mongodb.net:27017,cluster0-shard-00-01.9jh3r.mongodb.net:27017,cluster0-shard-00-02.9jh3r.mongodb.net:27017/?ssl=true&replicaSet=atlas-zd1grz-shard-0&authSource=admin&retryWrites=true&w=majority\",\r\n ";
        public static string DatabaseName { get;  } = "Octo-Umbrella";
        public static  string NoteCollectionName { get;  } = "Notes";
        public static string UserCollectionName { get; } = "Users";
    }
}
