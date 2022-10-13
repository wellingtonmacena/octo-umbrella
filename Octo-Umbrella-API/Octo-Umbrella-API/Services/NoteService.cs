using MongoDB.Driver;
using Octo_Umbrella_API.Data;
using Octo_Umbrella_API.Models;

namespace Octo_Umbrella_API.Services
{
    public class NoteService
    {
        private readonly IMongoCollection<Note> _notes;

        public IConfigurationSection Section { get; }

        public NoteService()
        {
            var mongoClient = new MongoClient(NoteDatabaseSettings.ConnectionString);

            _notes = mongoClient
                .GetDatabase(NoteDatabaseSettings.DatabaseName)
                .GetCollection<Note>(NoteDatabaseSettings.CollectionName);

        }

        public List<Note> GetAll() =>
         _notes.Find(_ => true).ToList();

        //public async Task<Note> Get(string id) =>
        //    await _notes.Find(s => s.Id == id).FirstOrDefaultAsync();

        public void Create(Note note) =>
             _notes.InsertOne(note);
    }
}
