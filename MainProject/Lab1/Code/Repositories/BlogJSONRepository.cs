using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.IO;

namespace CST465
{
    public class BlogJSONRepository : IDataEntityRepository<BlogPost>
    {
        public void Delete(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public BlogPost Get(int id)
        {
            BlogPost blog = null;

            List<BlogPost> blogList = GetList();

            blog = blogList.Where(b => b.ID == id).FirstOrDefault();

            return blog;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> blogList = new List<BlogPost>();
            string path = HttpContext.Current.Server.MapPath(@"~/App_Data/BlogData.json");
            string jsonString = null;

            using (StreamReader reader = new StreamReader(path))
            {
                jsonString = reader.ReadToEnd();
            }
            //string jsonString = System.IO.File.ReadAllText(path);

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            if (!String.IsNullOrEmpty(jsonString))
            {
                blogList = serializer.Deserialize<List<BlogPost>>(jsonString);
            }
            
            return blogList;
        }

        public void Save(BlogPost entity)
        {
            List<BlogPost> blogList = GetList();

            if (entity.ID == 0)
            {
             
                if(blogList.Count == 0)
                {
                    entity.ID = 1;
                }
                else
                {
                    entity.ID = blogList.Max(post => post.ID) + 1;
                }
                blogList.Add(entity);
            }
            else
            {
                BlogPost oldBlog = blogList.Where(blog => blog.ID == entity.ID).First();
                oldBlog.Author = entity.Author;
                oldBlog.Content = entity.Content;
                oldBlog.Timestamp = entity.Timestamp;
                oldBlog.Title = entity.Title;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(blogList);
            string path = HttpContext.Current.Server.MapPath(@"~/App_Data/BlogData.json");

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(jsonString);
            }

            //System.IO.File.WriteAllText(path, jsonString);
        }
    }
}