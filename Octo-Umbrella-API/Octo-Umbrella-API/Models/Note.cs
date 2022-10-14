using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Octo_Umbrella_API.Models
{
    public class Note
    {
        [BsonId]

        [JsonPropertyName("_id")]
        public string Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public Note(string title, string content)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Content = content;
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
        }
    }
}
