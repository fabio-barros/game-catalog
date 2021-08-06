using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace GameDataApp.Models
{
    public class GameModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id;

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string CoverArtUrl { get; set; }

        public decimal Price { get; set; }
    }
}
