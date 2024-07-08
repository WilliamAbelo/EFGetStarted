using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string TextoPuro { get; set; }

    public Post()
    {
        this.TextoPuro = string.Concat(DateTime.Now.ToShortDateString(), " qualquer coisa");
    }
}