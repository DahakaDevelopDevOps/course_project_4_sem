using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP_DD
{
    public class Entities
    {
        public class User
        {
            public int Id { get; set; }
            public string? Login { get; set; }
            public string? Email { get; set; }
            public bool? IsAdmin { get; set; }
        }

        public class Cars
        {
            public int Id { get; set; }
            public string? model { get; set; }
            public string? photo { get; set; }
            public int? total { get; set; }
            public bool? IsNewOrNot { get; set; }
            public string? descriptionshort { get; set; }
            public string? descriptionlarge { get; set; }
            public bool? isfavourite { get; set; }
        }
        public class FavoriteCars
        {
            public int Id { get; set;}
            public int? UserId { get; set; }
            public string? Users { get; set; }
            public int? CarId { get; set; }
        }
        public class Review
        {
            public int Id { get; set; }
            public string? Comment { get; set; }
        }
    }
}
