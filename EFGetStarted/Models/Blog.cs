using System;
using System.Collections.Generic;

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public DateTime CreatedTimestamp { get; set; }

    public List<Post> Posts { get; } = new();

    public Blog()
    {
        this.CreatedTimestamp = DateTime.Now;
    }
        

}