using MongoDB.Bson;
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

        public List<Note> GetAll()
        {
            return _notes.Find(_ => true).ToList();
        }

        public Note GetById(string id)
        {
            var note = _notes.Find(s => s.Id == id);
            if (note == null || note.CountDocuments() == 0) return null;

            return note.First();
        }


        public void Create(Note note)
        {
            try
            {
                _notes.InsertOne(note);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public Note Update(Note updatedNote, string id)
        {
            var filter = Builders<Note>.Filter.Eq(x => x.Id, id);
            var note = _notes.Find(filter).First();

            if (note == null)
                return null;

            note.Title = updatedNote.Title;
            note.Content = updatedNote.Content;
            note.LastModifiedDate = updatedNote.LastModifiedDate;
            _notes.ReplaceOneAsync(filter, note);

            return note;


        }

        public void DeleteById(string id)
        {
            var filter = Builders<Note>.Filter.Eq(x => x.Id, id);

            _notes.DeleteOneAsync(filter);
        }

        public void DeleteAll()
        {
            _notes.DeleteManyAsync(new BsonDocument { });
        }
    }
}
