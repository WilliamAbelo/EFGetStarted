using EFGetStarted;
using System;
using System.Collections.Generic;
using System.Linq;

using var db = new AppDbContext();
var blogService = new BlogService(db);

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Menu
var menu = "-1";
while (menu != "0")
{
    Console.WriteLine("\r\n\r\n1 - Inserir novo Blog\r\n" +
        "2 - Buscar a lista de Blogs\r\n" +
        "3 - Buscar um Blog\r\n" +
        "4 - Atualizar um Blog\r\n" +
        "5 - Deletar um Blog\r\n" +
        "\r\n" +
        "0 - Para Sair\r\n");
    var options = Console.ReadLine().ToLower();
    if (options == "0") break;
    ExecuteOptions(options);

}


void ExecuteOptions(string options)
{
    int id = 0;
    string strId = string.Empty;
    switch (options)
    {
        case ("1"):
            // Create
            Console.WriteLine("Inserting a new blog");
            blogService.CreateBlog();
            break;
        case ("2"):
            // Read
            Console.WriteLine("Querying for all blogs");
            IEnumerable<Blog> blogs = blogService.ListBlogs();
            foreach (var item in blogs)
            {
                Console.WriteLine($"BlogId: {item.BlogId} - Url: {item.Url} - CreatedAt: {item.CreatedTimestamp}");
            }
            break;
        case ("3"):
            // Read
            Console.WriteLine("Querying for a blogs");

            Console.WriteLine("Digite o Id do Blog");
            while (!Int32.TryParse(strId, out id))
            {
                strId = Console.ReadLine();
            }
            Blog blog = blogService.GetBlog(id);
            Console.WriteLine($"BlogId: {blog.BlogId} - Url: {blog.Url} - CreatedAt: {blog.CreatedTimestamp}\r\n");
            foreach (var item in blog.Posts)
            {
                Console.WriteLine($"PostId: {item.PostId} - Title: {item.Title} - Content: {item.Content} - BlogId: {item.BlogId} - Blog: {item.Blog} - TextoPuro: {item.TextoPuro}");
            }
            break;
        case ("4"):
            // Update
            Console.WriteLine("Updating the blog and adding a post");

            Console.WriteLine("Digite o Id do Blog");
            while (!Int32.TryParse(strId, out id))
            {
                strId = Console.ReadLine();
            }
            blogService.UpdateBlog(id);
            break;
        case ("5"):
            // Delete
            Console.WriteLine("Delete the blog");

            Console.WriteLine("Digite o Id do Blog");
            while (!Int32.TryParse(strId, out id))
            {
                strId = Console.ReadLine();
            }
            Console.WriteLine("Isso apagará o Blog e todos os seus Posts.Continuar? (s/n)");
            if(Console.ReadLine().ToLower() == "s") blogService.DeleteBlog(id);

            break;
        default:
            Console.WriteLine("\r\nOpção Invalida\r\n");
            break;
    }

}

