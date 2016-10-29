using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CST465
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        BlogPost IDataEntityRepository<BlogPost>.Get(int id)
        {
            BlogPost blog = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["troy_riblett"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * From BlogPosts Where ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (blog == null)
                        {
                            blog = new BlogPost
                            {
                                Author = (string)reader["Author"],
                                Content = (string)reader["Content"],
                                ID = (int)reader["ID"],
                                Timestamp = (DateTime)reader["Timestamp"],
                                Title = (string)reader["Title"]
                            };
                        }
                        else
                        {
                            throw new InvalidOperationException("Blog post data table contains more than one of id: " + id.ToString());
                        }
                    }
                }
            }


            return blog;
        }

        List<BlogPost> IDataEntityRepository<BlogPost>.GetList()
        {
            List<BlogPost> blogList = new List<BlogPost>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "Select * From BlogPosts";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        blogList.Add(new BlogPost
                        {
                            Author = (string)reader["Author"],
                            Content = (string)reader["Content"],
                            ID = (int)reader["ID"],
                            Timestamp = (DateTime)reader["Timestamp"],
                            Title = (string)reader["Title"]
                        });

                    }
                }
            }

            return blogList;
        }

        void IDataEntityRepository<BlogPost>.Save(BlogPost entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["troy_riblett"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    String failMessage = "";

                    if (entity.ID == 0)
                    {
                        failMessage = "Insert operation failed";
                        command.CommandText = "INSERT into BlogPosts (Author, Content, Timestamp, Title) Values (@Author, @Content, @Timestamp, @Title)";
                    }
                    else
                    {
                        failMessage = "Update operation failed";
                        command.CommandText = "UPDATE BlogPosts SET Author = @Author, Content = @Content, Timestamp = @Timestamp, Title=@Title WHERE ID = @ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }

                    command.Parameters.AddWithValue("@Author", entity.Author);
                    command.Parameters.AddWithValue("@Content", entity.Content);
                    command.Parameters.AddWithValue("@Timestamp", entity.Timestamp);
                    command.Parameters.AddWithValue("@Title", entity.Title);

                    if (command.ExecuteNonQuery() < 1)
                    {
                        throw new InvalidOperationException(failMessage);
                    }

                }
            }
        }
    }
}