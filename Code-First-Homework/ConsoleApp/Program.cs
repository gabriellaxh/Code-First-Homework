using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //AddBlogs();
            //AddPosts(1);
            //GetAllPosts();
            GetlAllPostsExplicit(1);

        }


        public static void AddBlogs()
        {
            using (var db = new BlogContext())
            {
                var blog1 = new Blog
                {
                    Title = "HelloWorld"
                };

                var blog2 = new Blog
                {
                    Title = "Dogs"
                };

                var blog3 = new Blog
                {
                    Title = "Astroworld"
                };

                db.Blogs.Add(blog1);
                db.Blogs.Add(blog2);
                db.Blogs.Add(blog3);
                db.SaveChanges();

            }
        }

        public static void AddPosts(int blogId)
        {
            using (var db = new BlogContext())
            {
                var post1 = new Post
                {
                    Content = "Description",
                    BlogId = blogId + 2

                };

                var post2 = new Post
                {
                    Content = "Hello hello",
                    BlogId = blogId + 3
                };

                db.Posts.Add(post1);
                db.Posts.Add(post2);
                db.SaveChanges();

            }
        }

        public static List<Blog> GetAllPostsEager()
        {
            using (var context = new BlogContext())
            {
                var blogs = context.Blogs.Include(x => x.Posts).ToList();

                return blogs;
            }
        }

        public static Blog GetlAllPostsExplicit(int blogId)
        {
            using (var context = new BlogContext())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var blog = context.Blogs.Single(b => b.Id == blogId);

                context.Entry(blog)
                    .Collection(b => b.Posts)
                    .Load();

                return blog;
            }
        }
    }
}
