using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class TodoItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Title { get; set; }
    public bool IsDone { get; set; }
}