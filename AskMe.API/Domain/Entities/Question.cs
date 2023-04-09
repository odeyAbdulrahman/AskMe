using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AskMe.API.Domain.Entities
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Code { get; set; } 
        public string? Title { get; set; }
        public string? TitleAR { get; set; }
        public string? Details { get; set; }
        public string? DetailsAR { get; set; }
        public Writer? WriterInfo { get; set; }
        public List<Answer>? Answers { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
