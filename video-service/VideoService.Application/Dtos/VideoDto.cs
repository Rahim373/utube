﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VideoService.Application.Dtos
{
    public class VideoDto
    {
        public string? Id { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid VideoId { get; set; }
        public DateTime UploadedOn { get; set; } = DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string[]? Tags { get; set; }
        public string DefaultThumbnail { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string Channel { get; set; } = string.Empty;
        public string[]? Thumbnails { get; set; }
        public string? Playlist { get; set; }
        public string? Duration { get; set; }
        public int Views { get; set; }
    }
}
