using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DailyPrice.API.Core
{
    /// <summary>
    /// Represents the base entity
    /// </summary>
    public abstract class BaseEntity
    {
         /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}