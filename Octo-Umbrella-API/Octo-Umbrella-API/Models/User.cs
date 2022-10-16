using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Octo_Umbrella_API.Models
{
    public class User
    {
        [BsonId]

        [JsonPropertyName("_id")]
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [JsonConstructor]
        public User(string fullName, string email, string password)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            Email = email;
            Password = password;
            CreatedDate = DateTime.Now;
            LastModifiedDate = CreatedDate;
        }
    }
}
