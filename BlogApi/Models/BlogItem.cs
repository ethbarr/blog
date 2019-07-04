using System;

namespace BlogApi.Models
{
    public class BlogItem
    {
        public long Id {get; set;}
        public string Title {get; set;}
        public string Body {get; set;}
        public DateTime TimeStamp {get; set;}
    }
}