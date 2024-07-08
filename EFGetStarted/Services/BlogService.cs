using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    class BlogService
    {
        private AppDbContext db;
        public BlogService(AppDbContext appDbContext)
        {
            db = appDbContext;
        }
        public void CreateBlog()
        {
            db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            db.SaveChanges();
        }

        public IEnumerable<Blog> ListBlogs()
        {
            return db.Blogs;
        }

        public Blog GetBlog(int id)
        {
            return (Blog)db.Blogs.Where(b => b.BlogId == id).Include(b => b.Posts).FirstOrDefault();
        }

        public void UpdateBlog(int id) 
        {
            Blog blog = db.Blogs.Single(b => b.BlogId == id);
            blog.Url = "https://devblogs.microsoft.com/dotnet";
            blog.Posts.Add(
                new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
            db.SaveChanges();
        }

        public void DeleteBlog(int id) 
        {
            Blog blog = db.Blogs.Single(b => b.BlogId == id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
        }  
    }
}
